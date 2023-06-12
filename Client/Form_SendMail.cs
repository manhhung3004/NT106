using MailKit.Net.Imap;
using MailKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MailKit.Net.Pop3;
using MailKit.Search;

namespace Client
{
    public partial class Form_SendMail : Form
    {
        public Form_SendMail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMail();
        }

        private void button_PhanHoi_Click(object sender, EventArgs e)
        {
            SendMailSMTP sendMailSMTP = new SendMailSMTP()
            {
                Taikhoan = textBox_email.Text,
                Matkhau = textBox_password.Text,
            };
            sendMailSMTP.ShowDialog();
        }

        private void LoadMail()
        {
            button_DangNhap.Hide();
            button_refresh.Show();
            button_PhanHoi.Show();
            listView1.Show();
            textBox_email.ReadOnly = true;
            textBox_password.ReadOnly = true;
            try
            {
                var client = new ImapClient();
                client.Connect("imap.gmail.com", 993, true); // imap host, port, use ssl.
                client.Authenticate(textBox_email.Text, textBox_password.Text); // gmail accout, app password.

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);


                this.listView1.View = View.Details;
                listView1.Columns.Add("Email", 400, HorizontalAlignment.Center);
                listView1.Columns.Add("From", 200, HorizontalAlignment.Center);
                listView1.Columns.Add("Date", 100, HorizontalAlignment.Center);
                for (int i = inbox.Count - 1; i >= inbox.Count - 1 - 10; i--)
                {
                    var message = inbox.GetMessage(i);

                    var item2 = new ListViewItem(new[] { message.Subject, message.From.ToString(), message.Date.ToString() });

                    listView1.Items.Add(item2);
                }

                //Hiển thị số mail
                lbTotal.Text = inbox.Count.ToString();
                lbRecent.Text = client.Inbox.Search(SearchQuery.NotSeen).Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Form_SendMail_Load(object sender, EventArgs e)
        {
            listView1.Hide();
            button_PhanHoi.Hide();
            button_refresh.Hide();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
           listView1.Clear();
           LoadMail();
        }
    }
}
