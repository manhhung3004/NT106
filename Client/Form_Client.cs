using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Client
{
    public partial class Form_Client : Form
    {
        UdpClient client;
        IPEndPoint endPoint;

        public string englishWord;
        public string vietnameseMeaning;
        public GroupBox groupBox;

        public Form_Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new UdpClient();
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),int.Parse("8088"));
            try
            {
                client.Connect(endPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (client != null && client.Client.Connected)
            {
                // Lấy nội dung tin nhắn từ textBox_Word
                englishWord = textBox_Word.Text.Trim();

                // Gửi nội dung tin nhắn đến ứng dụng A
                byte[] sendBytes = Encoding.UTF8.GetBytes(englishWord);
                client.Send(sendBytes, sendBytes.Length);

                // Nhận kết quả trả về từ ứng dụng A5
                byte[] receiveBytes = client.Receive(ref endPoint);
                vietnameseMeaning = Encoding.UTF8.GetString(receiveBytes);

                Form_Translation form_Translation = new Form_Translation()
                {
                    EnglishWord = englishWord,
                    VietnameseMeaning = vietnameseMeaning
                };
                form_Translation.Show();
                History(englishWord,vietnameseMeaning);
            }
            else
            {
                MessageBox.Show("Please connect to server first...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void History( string EngLish, string VietNamese)
        {
            groupBox = new GroupBox
            {
                MinimumSize = new Size(315, 90),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            Label lb_Eng = new Label
            {
                Text = EngLish,
                Location = new Point(140, 10),
                AutoSize = true,
                Size = new Size(298, 20),
                MaximumSize = new Size(298, 20),
                Font = new Font("Times New Roman", 8, FontStyle.Bold)

            };
            groupBox.Controls.Add(lb_Eng);

            string text_Show;
            if (Check_Word(vietnameseMeaning))
            {
               text_Show = Substring_Meaning_Word(vietnameseMeaning);
            }
            else
            {
                text_Show = vietnameseMeaning;
            }

            Label lb_Viet = new Label
            {
                Text = text_Show,
                Font = new Font("Times New Roman", 8, FontStyle.Regular),
                Location = new Point(20, 30),
                AutoSize = true,
                Size = new Size(292, 20),
                MaximumSize = new Size(292, 90),
            };
            groupBox.Controls.Add(lb_Viet);
            flowLayoutPanel1.Controls.Add(groupBox);
        }

        private void Client_Load(object sender, EventArgs e)
        {
            //if( )
        }

        public string Substring_Meaning_Word(string a)
        {

            if (string.IsNullOrEmpty(a))
            {
                return null;
            }
            else
            {
                int startIndex = a.IndexOf('<');
                int endIndex = a.IndexOf('>');
                if (startIndex >= 0 && endIndex >= 0 && endIndex > startIndex)
                {
                    string answer = a.Substring(startIndex + 1, endIndex - startIndex - 1);
                    return answer;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool Check_Word (string word)
        {
            foreach (char c in word)
            {
                if (c == '<') { return true; }
            }
            return false;
        }

        private void bt_Note_Click(object sender, EventArgs e)
        {
            Forms_Note forms_Note = new Forms_Note()
            {
                SqlConnection = sql,
                Taikhoan = taikhoan,
                Matkhau = matkhau,
            };
            forms_Note.Show();
        }

        // Lấy dữ liệu từ form_login
        private SqlConnection sql;
        public SqlConnection Sql
        {
            get { return sql; }
            set { sql = value; }
        }

        private string taikhoan;
        public string Taikhoan
        {
            get { return taikhoan; }
            set { taikhoan = value; }
        }

        // Giữ connect sql
        private string matkhau;
        public string Matkhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.ResumeLayout();
        }
    }
}
