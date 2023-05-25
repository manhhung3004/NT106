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

namespace Client
{
    public partial class Client : Form
    {
        TcpClient client;
        Thread Th_Connect;
        Thread Th_SendData;
        Thread Th_ReceiveData;

        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (client != null & client.Connected)
            {

                // Nhập chuỗi tiếng Anh từ bàn phím
                string englishWord = textBox_Word.Text.Trim();

                // Gửi chuỗi tiếng Anh đến ứng dụng A
                byte[] buffer = Encoding.UTF8.GetBytes(englishWord);
                client.GetStream().Write(buffer, 0, buffer.Length);

                // Đọc kết quả trả về từ ứng dụng A
                byte[] responseBuffer = new byte[client.ReceiveBufferSize];
                int bytesRead = client.GetStream().Read(responseBuffer, 0, client.ReceiveBufferSize);
                string vietnameseMeaning = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
                // Hiển thị kết quả trả về lên màn hình
                listBox1.Items.Add(englishWord + " is " + vietnameseMeaning);
            }
            else
            {
                MessageBox.Show("Do not Send!!!!!!!!!");
            }
            //client.Close();
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            client = new TcpClient();

            try {
                client.Connect(textBox_ip.Text, int.Parse(textBox_port.Text));
                listBox1.Items.Add("Starting.....");
                if (client.Connected)
                {
                    listBox1.Items.Add("Connected!!!!");
                }
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
