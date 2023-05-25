using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhMang
{
    public partial class Server : Form
    {

        private TcpListener server;
        private TcpClient client;
        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            { "Computer", "Máy tính" },
            { "RAM", "Bộ nhớ trong" },
            { "HDD", "Ổ đĩa cứng" }
        };

        public Server()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Any, int.Parse(textBox_port.Text));
            server.Start();
            listBox1.Items.Add("Server start listen......");
            Task.Factory.StartNew(() => ListenForRequests());
        }

        private void ListenForRequests()
        {
            try
            {
                // Chấp nhận kết nối từ ứng dụng B
                client = server.AcceptTcpClient();

                if (client != null && client.Connected)
                {
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(new Action<string>(AddItemToListBox), "Connected!!!!");
                    }
                    else
                    {
                        listBox1.Items.Add("Connected!!!!");
                    }

                    // Đọc chuỗi tiếng Anh từ ứng dụng B
                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int bytesRead = client.GetStream().Read(buffer, 0, client.ReceiveBufferSize);
                    string englishWord = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Tìm kiếm nghĩa tiếng Việt tương ứng trongtừ điển
                    string vietnameseMeaning = "";
                    if (dictionary.ContainsKey(englishWord))
                    {
                        vietnameseMeaning = dictionary[englishWord];
                    }
                    else
                    {
                        vietnameseMeaning = "Not Found";
                    }

                    // Gửi trả lại nghĩa tiếng Việt tương ứng cho ứng dụng B
                    byte[] responseBuffer = Encoding.UTF8.GetBytes(vietnameseMeaning);
                    client.GetStream().Write(responseBuffer, 0, responseBuffer.Length);

                    // Hiển thị lên listBox1
                    if (listBox1.InvokeRequired)
                    {
                        listBox1.Invoke(new Action<string>(AddItemToListBox), englishWord + " is " + vietnameseMeaning);
                    }
                    else
                    {
                        listBox1.Items.Add(englishWord + " is " + vietnameseMeaning);
                    }
                }
                else
                {
                    MessageBox.Show("Connect fail");
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("SocketException: " + ex.Message);
            }
            catch (ObjectDisposedException ex)
            {
                MessageBox.Show("ObjectDisposedException: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối với ứng dụng B
                if (client != null)
                {
                    client.Close();
                }
            }
        }
    }
}
