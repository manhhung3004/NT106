using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Forms_Note : Form
    {
        public Forms_Note()
        {
            InitializeComponent();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            // Thằng này auto đóng
           if(sqlConnection.State == ConnectionState.Closed)
           {
                MessageBox.Show("Connection đã đóng");
           }
           else
           {
                string sql = "UPDATE Tk_Nguoidung SET Note = @Note WHERE TaiKhoan = '" + taikhoan + "' AND MatKhau = '" + matkhau + "'";
                using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                {
                    string note = richTextBox1.Text;
                    command.Parameters.AddWithValue("@Note", note);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu không thành công!");
                    }
                }
           }
        }

        private void Forms_Note_Load(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                MessageBox.Show("Connection đã đóng");
            }
            else
            {
                string sql = "SELECT * FROM Tk_Nguoidung WHERE TaiKhoan = '" + taikhoan + "' AND MatKhau = '" + matkhau + "'";
                using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("Note")))
                            {
                                string note = reader.GetString(reader.GetOrdinal("Note"));
                                richTextBox1.Text = note;
                            }
                            else
                            {
                                richTextBox1.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu!");
                    }
                    reader.Close();
                }
            }
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

        private SqlConnection sqlConnection;
        public SqlConnection SqlConnection
        {
            get { return sqlConnection; }
            set { sqlConnection = value; }
        }
    }
}
