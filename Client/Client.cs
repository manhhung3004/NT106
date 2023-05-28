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

        private void button1_Click(object sender, EventArgs e)
        {
            if (client != null && client.Client.Connected)
            {
                // Lấy nội dung tin nhắn từ textBox_Word
                string englishWord = textBox_Word.Text.Trim();

                // Gửi nội dung tin nhắn đến ứng dụng A
                byte[] sendBytes = Encoding.UTF8.GetBytes(englishWord);
                client.Send(sendBytes, sendBytes.Length);

                // Nhận kết quả trả về từ ứng dụng A
                byte[] receiveBytes = client.Receive(ref endPoint);
                string vietnameseMeaning = Encoding.UTF8.GetString(receiveBytes);

                // Hiển thị kết quả trả về lên listBox1
                if (englishWord == "Hello")
                {
                    listBox1.Items.Add($"{englishWord}");
                }
                else
                {
                    listBox1.Items.Add($"{englishWord} is {vietnameseMeaning}");
                }
            }
            else
            {
                MessageBox.Show("Please connect to server first...");
            }
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            client = new UdpClient();
            endPoint = new IPEndPoint(IPAddress.Parse(textBox_ip.Text), int.Parse(textBox_port.Text));
            listBox1.Items.Clear();

            try
            {
                client.Connect(endPoint);
                listBox1.Items.Add("Connected to server...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
