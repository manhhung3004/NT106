using Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Client
{
    public partial class Form_Translation : Form
    {
        private PictureBox pictureBox;
        // Lấy từ tiếng anh nhập từ client
        private string englishWord = "";
        public string EnglishWord
        { get { return englishWord; }
            set { englishWord = value; }
        }

        // Lấy nghĩa tiếng việt được nhận từ server gửi về cho client
        private string vietnameseMeaning = "";
        public string VietnameseMeaning
        {
            get { return vietnameseMeaning; }
            set { vietnameseMeaning = value; }
        }

        public Form_Translation()
        {
            InitializeComponent();
        }

        private void Form_Translation_Load(object sender, EventArgs e)
        {
            pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BorderStyle = BorderStyle.None; 
            pictureBox.Size = new Size(292, 271);
            pictureBox.Location = new Point(62, 33);
            pictureBox.BringToFront();
            pictureBox.Image = System.Drawing.Image.FromFile(@"D:\HocTap\Nam2-Ki_2\Lập trình mạng căn bản\Template\not-found.png");

            if (string.IsNullOrEmpty(vietnameseMeaning))
            {
                label1.Text = "Not Found";
            }
            else
            {
                if(vietnameseMeaning.ToString() == "Not Found")
                {
                    label1.Hide();
                    label2.Hide();
                    //Hiển thị nỏ found
                    try
                    {
                        pictureBox.Show();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);  
                    }
                    
                }
                else
                {
                    label1.Show(); label2.Show();
                    label1.Text = $"{Substring_Meaning_Word(vietnameseMeaning)}";
                    label2.Text = $"{Substring_Word(vietnameseMeaning)} ";
                    pictureBox.Hide();
                }
                
            }
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

        public string Substring_Word(string a)
        {

            if (string.IsNullOrEmpty(a))
            {
                return null;
            }
            else
            {
                int startIndex = a.IndexOf('(');
                int endIndex = a.IndexOf(')');
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
    }

}
