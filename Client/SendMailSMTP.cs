using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client
{
    public partial class SendMailSMTP : Form
    {
        public SendMailSMTP()
        {
            InitializeComponent();
        }

        private void SendMailSMTP_Load(object sender, EventArgs e)
        {
            textBox_emailFrom.Text = taikhoan;
        }

        private void button_Gui_Click(object sender, EventArgs e)
        {
            var smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465, true);
            try
            {
                smtpClient.Authenticate(taikhoan, Matkhau);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(textBox_Object.Text, textBox_emailFrom.Text));
            message.To.Add(new MailboxAddress(textBox_Object.Text, textBox_EmailTo.Text));
            message.Subject = textBox_Object.Text;
            message.Body = new TextPart("plain")
            {
                Text = richTextBox1.Text
            };

            smtpClient.Send(message);
            MessageBox.Show("Gửi thành công");
            Close();
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

        // Tệp đính kèm
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
