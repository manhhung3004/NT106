using MailKit.Net.Smtp;
using MailKit.Security;
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

        public string filepath;

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

            if (filepath == null)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(textBox_emailFrom.Text, textBox_emailFrom.Text));
                message.To.Add(new MailboxAddress(textBox_EmailTo.Text, textBox_EmailTo.Text));
                message.Subject = textBox_Object.Text;

                // Thiết lập nội dung email
                var builder = new BodyBuilder();
                builder.TextBody = richTextBox1.Text;

                // Thiết lập nội dung email đã được xây dựng
                message.Body = builder.ToMessageBody();

                // Gửi email
                smtpClient.Send(message);
                smtpClient.Disconnect(true);

                MessageBox.Show("Đã gửi thành công!");
            }
            else
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(textBox_emailFrom.Text, textBox_emailFrom.Text));
                message.To.Add(new MailboxAddress(textBox_EmailTo.Text, textBox_EmailTo.Text));
                message.Subject = textBox_Object.Text;
                var builder = new BodyBuilder();
                builder.TextBody = richTextBox1.Text;

                // Thêm tệp đính kèm
                builder.Attachments.Add(filepath);

                // Thiết lập nội dung email
                message.Body = builder.ToMessageBody();

                // Gửi email
                smtpClient.Send(message);
                smtpClient.Disconnect(true);

                MessageBox.Show("Đã gửi thành công!");
            }
         
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đến tệp tin được chọn
                filepath = openFileDialog.FileName;
                label_att.Text = filepath;
            }
        }
    }
}
