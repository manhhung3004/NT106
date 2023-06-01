using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Client : Form
    {
        UdpClient client;
        IPEndPoint endPoint;

        public Client()
        {
            InitializeComponent();
        }

        public int temp = 0;
        public string englishWord;
        public string vietnameseMeaning;
        public GroupBox groupBox;

        private void button1_Click(object sender, EventArgs e)
        {
            client = new UdpClient();
            endPoint = new IPEndPoint(IPAddress.Parse(textBox1.Text),int.Parse(textBox2.Text));
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
                form_Translation.ShowDialog();
                temp++;
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
            for (int i = 0; i < temp; i++)
            {
                groupBox = new GroupBox();
                groupBox.AutoSize = true;
                groupBox.AutoSizeMode = AutoSizeMode.GrowOnly;

                Label lb_Eng = new Label
                {
                    Text = EngLish,
                    Location = new Point(50, 10),
                    AutoSize = true,
                    Size = new Size(298, 20),
                    MaximumSize = new Size(298, 20),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                groupBox.Controls.Add(lb_Eng);

                Label lb_Viet= new Label
                {
                    Text = vietnameseMeaning,
                    Location = new Point(20, 30),
                    AutoSize = true,
                    Size = new Size(298, 20),
                    MaximumSize = new Size(298, 20)
                };
                groupBox.Controls.Add(lb_Viet);
                flowLayoutPanel1.Controls.Add(groupBox);
            }
        }
    }
}
