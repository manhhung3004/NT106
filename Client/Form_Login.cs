using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;    
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public partial class Form_Login : Form
    {
        UdpClient clientServer;
        IPEndPoint endPoint;

        private string Taikhoan = "";
        private string Matkhau = "";

        public Form_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Taikhoan = textBox_tk.Text;
            Matkhau = textBox_mk.Text;
            try
            {
                if (ConnectToServer(Taikhoan, Matkhau))
                {
                    Form_Main form_Main = new Form_Main()
                    {
                        Taikhoan = Taikhoan,
                        Matkhau = Matkhau,
                        client = clientServer,
                        endPoint = endPoint
                    };
                    Hide();
                    form_Main.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!!!! Vui lòng kiểm tra lại tài khoản hoặc mật khẩu của bạn");
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
            Application.Exit();
        }

        private bool ConnectToServer(string username, string password)
        {
            clientServer = new UdpClient();
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8088);
            try
            {
                clientServer.Connect(endPoint);
                // Gửi tài khoản và mật khẩu để kiểm tra
                byte[] sendBytes = Encoding.UTF8.GetBytes(username + ";" + password);
                clientServer.Send(sendBytes, sendBytes.Length);

                // Nhận kết quả 
                byte[] receiveBytes = clientServer.Receive(ref endPoint);
                string result = Encoding.UTF8.GetString(receiveBytes);
                if (result == "True") { return true; }
                else { return false; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Register form_Register = new Form_Register() 
            {
                Taikhoan = Taikhoan,
                Matkhau = Matkhau,
                client = clientServer,
                endPoint = endPoint
            };
            form_Register.ShowDialog();
        }
    }
}
