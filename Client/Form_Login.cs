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

namespace Client
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=MANHHUNG;Initial Catalog=QuanLy;Integrated Security=True");
                sqlConnection.Open();
                string tk = textBox_tk.Text;
                string mk = textBox_mk.Text;
                string sql = "SELECT * FROM Tk_Nguoidung WHERE TaiKhoan = '" + tk + "' AND MatKhau = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Đăng nhập thành công");
                    Hide();
                    Form_Client client = new Form_Client()
                    {
                        Sql = sqlConnection,
                        Taikhoan = tk,
                        Matkhau = mk,
                    };
                    rdr.Close();
                    client.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                    textBox_tk.Focus();
                }
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
    }
}
