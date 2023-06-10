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
            if (!string.IsNullOrEmpty(vietnameseMeaning))
            {
                if (vietnameseMeaning.ToString() == "Not Found")
                {
                    label1.Hide();
                    label2.Hide();
                    MessageBox.Show("Not Found!!!!!!");
                }
                else
                {
                    label1.Show(); label2.Show();
                    label1.Text = $"{Substring_Meaning_Word(vietnameseMeaning)}";
                    label2.Text = $"{Substring_Word(vietnameseMeaning)} ";
                }
            }
            Hide();
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
