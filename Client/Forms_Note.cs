﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class Forms_Note : Form
    {
        public Forms_Note()
        {
            InitializeComponent();
        }

        string Data;

        private void button_save_Click(object sender, EventArgs e)
        {
            // Gửi cờ hiệu lệnh lưu
            byte[] sendBytes = Encoding.UTF8.GetBytes("flag Saved");
            client.Send(sendBytes, sendBytes.Length);

            byte[] receiveBytes = client.Receive(ref endPoint);
            Data = Encoding.UTF8.GetString(receiveBytes);

            if(Data == "True")
            {
                if(richTextBox1.Text == null)
                {
                    richTextBox1.Text = "";
                    string DataSaved = richTextBox1.Text;
                    byte[] sendBytes1 = Encoding.UTF8.GetBytes(DataSaved);
                    client.Send(sendBytes1, sendBytes1.Length);
                }
                else
                {
                    string DataSaved = richTextBox1.Text;
                    byte[] sendBytes1 = Encoding.UTF8.GetBytes(DataSaved);
                    client.Send(sendBytes1, sendBytes1.Length);
                }
                
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }

        }

        private void Forms_Note_Load(object sender, EventArgs e)
        {
            // Nhận data về để load
            byte[] receiveBytes = client.Receive(ref endPoint);
            Data = Encoding.UTF8.GetString(receiveBytes);
            richTextBox1.Text = Data;
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            Hide();
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

        private UdpClient client;
        public UdpClient Client
        {
            get { return client; }
            set { client = value; }
        }

        private IPEndPoint endPoint;
        public IPEndPoint Endpoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        private void button_Luu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lưu nội dung văn bản thuần túy của RichTextBox vào tệp
                    File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                }
            }
        }
    }
}
