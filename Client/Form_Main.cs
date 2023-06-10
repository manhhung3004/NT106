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

namespace Client
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private Form currentformchild;
        private void OpenChilForm(Form ChilFrom)
        {
            if (currentformchild != null)
            {
                currentformchild.Close();
            }
            currentformchild = ChilFrom;
            ChilFrom.TopLevel = false;
            ChilFrom.FormBorderStyle = FormBorderStyle.None;
            ChilFrom.Dock = DockStyle.Fill;
            panel_body.Controls.Add(ChilFrom);
            panel_body.Tag = ChilFrom;
            ChilFrom.BringToFront();
            ChilFrom.Show();
        }

        private void button_tran_Click(object sender, EventArgs e)
        {
            Form_Client form_Client = new Form_Client()
            {
                Taikhoan = Taikhoan,
                Matkhau = Matkhau,
                client = client,
                endPoint = endPoint
            };

            OpenChilForm(form_Client);
        }

        private void button_Note_Click(object sender, EventArgs e)
        {
            byte[] sendBytes = Encoding.UTF8.GetBytes("flag moved");
            client.Send(sendBytes, sendBytes.Length);

            Forms_Note form_Note= new Forms_Note()
            {
                Taikhoan = Taikhoan,
                Matkhau = Matkhau,
                Client = client,
                Endpoint= endPoint
            };
            OpenChilForm(form_Note);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {

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

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            client.Close();
            endPoint = null;
            Close();
            Application.Exit();
        }

        private void button_Sendmail_Click(object sender, EventArgs e)
        {
            Form_SendMail form_SendMail = new Form_SendMail();
            OpenChilForm(form_SendMail);
        }
    }
}
