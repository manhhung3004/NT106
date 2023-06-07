﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DoAnLapTrinhMang
{
    public partial class Server : Form
    {
        private bool _connected = true;
        private UdpClient server;
        private IPEndPoint endPoint;
        public SqlConnection sqlConnection;
        public SqlCommand command;
        public SqlDataReader reader;

        public Server()
        {
            InitializeComponent();
            button2.Hide();
            InitServer();
        }

        private void InitServer()
        {
            server = new UdpClient(8088);
            endPoint = new IPEndPoint(IPAddress.Any, 8088);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _connected = true;
            Task.Factory.StartNew(() => ListenForRequestsAsync());
            button1.Hide();
            button2.Show();
        }

        private async Task ListenForRequestsAsync()
        {
            try
            {
                string note;
                byte[] receiveBytes;
                string[] loginData;
                string username;
                string password;
                string englishText;
                string vietnameseText;
                byte[] sendBytes;

                while (true)
                {
                    receiveBytes = server.Receive(ref endPoint);
                    loginData = Encoding.UTF8.GetString(receiveBytes).Split(';');
                    username = loginData[0];
                    password = loginData[1];

                    if (CheckLogin(username, password))
                    {
                        sendBytes = Encoding.UTF8.GetBytes("True");
                        server.Send(sendBytes, sendBytes.Length, endPoint);

                        bool formNoteFlag = false;
                        bool updateNoteFlag = false;

                        while (true)
                        {
                            receiveBytes = server.Receive(ref endPoint);
                            englishText = Encoding.UTF8.GetString(receiveBytes);

                            if (englishText == "flag moved")
                            {
                                formNoteFlag = true;
                                updateNoteFlag = false;
                            }
                            else if (englishText == "flag Saved")
                            {
                                formNoteFlag = false;
                                updateNoteFlag = true;
                            }
                            else
                            {
                                formNoteFlag = false;
                                updateNoteFlag = false;
                            }

                            if (formNoteFlag)
                            {
                                if (sqlConnection.State == ConnectionState.Closed)
                                {
                                    MessageBox.Show("Connection đã đóng");
                                }
                                else
                                {
                                    string sql = "SELECT * FROM Tk_Nguoidung WHERE TaiKhoan = @Username AND MatKhau = @Password";
                                    using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                                    {
                                        command.Parameters.AddWithValue("@Username", username);
                                        command.Parameters.AddWithValue("@Password", password);
                                        SqlDataReader reader = command.ExecuteReader();
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                if (!reader.IsDBNull(reader.GetOrdinal("Note")))
                                                {
                                                    note = reader.GetString(reader.GetOrdinal("Note"));
                                                    sendBytes = Encoding.UTF8.GetBytes(note);
                                                    server.Send(sendBytes, sendBytes.Length, endPoint);
                                                }
                                                else
                                                {
                                                    note = "";
                                                    sendBytes = Encoding.UTF8.GetBytes(note);
                                                    server.Send(sendBytes, sendBytes.Length, endPoint);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Không tìm thấy dữ liệu!");
                                        }
                                        reader.Close();
                                    }
                                }
                            }
                            else if (updateNoteFlag)
                            {
                                // Trả về true cho Form_Note
                                sendBytes = Encoding.UTF8.GetBytes("True");
                                server.Send(sendBytes, sendBytes.Length, endPoint);

                                receiveBytes = server.Receive(ref endPoint);
                                note = Encoding.UTF8.GetString(receiveBytes);

                                if (sqlConnection.State == ConnectionState.Closed)
                                {
                                    MessageBox.Show("Connection đã đóng");
                                }
                                else
                                {
                                    string sql = "UPDATE Tk_Nguoidung SET Note = @Note WHERE TaiKhoan = @Username AND MatKhau = @Password";
                                    using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                                    {
                                        command.Parameters.AddWithValue("@Note", note);
                                        command.Parameters.AddWithValue("@Username", username);
                                        command.Parameters.AddWithValue("@Password", password);
                                        int result = command.ExecuteNonQuery();
                                        if (result > 0)
                                        {
                                            MessageBox.Show("Thêm dữ liệu thành công!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Thêm dữ liệu không thành công!");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Dịch chuỗi tiếng Anh và gửi kết quả dịch tiếng Việt cho client
                                vietnameseText = await TranslateText(englishText);
                                sendBytes = Encoding.UTF8.GetBytes(vietnameseText);
                                server.Send(sendBytes, sendBytes.Length, endPoint);
                            }
                        }
                    }
                    else
                    {
                        sendBytes = Encoding.UTF8.GetBytes("False");
                        server.Send(sendBytes, sendBytes.Length, endPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection.State != ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _connected = false;
            button1.Show();
            button2.Hide();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            server.Close();
            Application.Exit();
            Close();
        }

        public async Task<string> TranslateText(string input)
        {
            // Set the language from/to in the url (or pass it into this function)
            string url = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                                        "en", "vi", Uri.EscapeUriString(input));
            HttpClient httpClient = new HttpClient();
            string result = await httpClient.GetStringAsync(url);

            // Get all json data
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);

            // Extract just the first array element (This is the only data we are interested in)
            var translationItems = jsonData[0];

            // Translation Data
            string translation = "";

            // Loop through the collection extracting the translated objects
            foreach (object item in translationItems)
            {
                // Convert the item array to IEnumerable
                IEnumerable translationLineObject = item as IEnumerable;

                // Convert the IEnumerable translationLineObject to a IEnumerator
                IEnumerator translationLineString = translationLineObject.GetEnumerator();

                // Get first object in IEnumerator
                translationLineString.MoveNext();

                // Save its value (translated text)
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }

            // Remove first blank character
            if (translation.Length > 1) { translation = translation.Substring(1); };

            // Return translation
            return translation;
        }

        private bool CheckLogin(string username, string password)
        {
            sqlConnection = new SqlConnection(@"Data Source=MANHHUNG;Initial Catalog=QuanLy;Integrated Security=True");
            command = new SqlCommand("SELECT * FROM Tk_Nguoidung WHERE TaiKhoan = @Taikhoan AND MatKhau = @Matkhau", sqlConnection);
            command.Parameters.AddWithValue("@Taikhoan", username);
            command.Parameters.AddWithValue("@Matkhau", password);

            try
            {
                sqlConnection.Open();
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
