﻿using System;
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

        public string englishWord;
        public string vietnameseMeaning;
        public GroupBox groupBox;

        public Form_Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

                History(englishWord,vietnameseMeaning);
            }
            else
            {
                MessageBox.Show("Dịch bị lôi!!!!!!!");
            }
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

            Label lb_Viet = new Label
            {
                Text = vietnameseMeaning,
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
            Forms_Note forms_Note = new Forms_Note()
            {
                //SqlConnection = sql,
                Taikhoan = taikhoan,
                Matkhau = matkhau,
                Client = Client,
                Endpoint = Endpoint,
            };

        }

        // Lấy dữ liệu từ form_login

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

        public UdpClient client;
        public UdpClient Client
        {
            get { return client; }
            set { client = value; }
        }

        public IPEndPoint endPoint;
        public IPEndPoint Endpoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.ResumeLayout();
        }
    }
}
