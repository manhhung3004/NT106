using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Form_Register : Form
    {
        public Form_Register()
        {
            InitializeComponent();
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


        private string taikhoan;
        public string Taikhoan
        {
            get { return taikhoan; }
            set { taikhoan = value; }
        }

        private string matkhau;
        public string Matkhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }

        private void button_xn_Click(object sender, EventArgs e)
        {

        }

        private void button_dk_Click(object sender, EventArgs e)
        {
            if (textBox_Mk.Text == textBox_MkXn.Text)
            {
                try
                {
                    using (var client = new UdpClient())
                    {
                        var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8088);

                        // Gửi yêu cầu kiểm tra tài khoản
                        var sendBytes = Encoding.UTF8.GetBytes("Check_account" + ";" + textBox_tk.Text);
                        client.Send(sendBytes, sendBytes.Length, endPoint);

                        // Nhận kết quả 
                        var receiveBytes = client.Receive(ref endPoint);
                        var result = Encoding.UTF8.GetString(receiveBytes);

                        if (result == "True")
                        {
                            MessageBox.Show("Đã có tài khoản đăng ký!!!! Mời bạn thử lại bằng 1 tài khoản khác!!!");
                        }
                        else
                        {
                            // Gửi yêu cầu đăng ký tài khoản mới
                            sendBytes = Encoding.UTF8.GetBytes(textBox_tk.Text + ";" + textBox_Mk.Text);
                            client.Send(sendBytes, sendBytes.Length, endPoint);

                            // Nhận kết quả 
                            receiveBytes = client.Receive(ref endPoint);
                            result = Encoding.UTF8.GetString(receiveBytes);

                            if (result == "True")
                            {
                                MessageBox.Show("Đăng ký tài khoản thành công!!!");
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Đăng ký tài khoản thất bại!!! Mời bạn thử lại!!!");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu bị sai!! Vui lòng thử lại");
            }
        }
    }
}
