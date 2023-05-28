using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhMang
{
    public partial class Server : Form
    {

        private UdpClient server;
        private IPEndPoint endPoint;
        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            { "Computer", "Máy tính" },
            { "RAM", "Bộ nhớ trong" },
            { "HDD", "Ổ đĩa cứng" }
        };

        public Server()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server = new UdpClient(int.Parse(textBox_port.Text));
            endPoint = new IPEndPoint(IPAddress.Any, int.Parse(textBox_port.Text));
            listBox1.Items.Clear();
            listBox1.Items.Add("Server started...");
            Task.Factory.StartNew(() => ListenForRequests());
        }

        private void ListenForRequests()
        {
            while (true)
            {
                // Nhận dữ liệu từ ứng dụng B
                byte[] receiveBytes = server.Receive(ref endPoint);
                string englishWord = Encoding.UTF8.GetString(receiveBytes);

                // Tìm kiếm nghĩa tiếng Việt tương ứng trong từ điển
                string vietnameseMeaning = "";                
                if (dictionary.ContainsKey(englishWord))
                {
                    vietnameseMeaning = dictionary[englishWord];
                }
                else
                {
                    vietnameseMeaning = "Not Found";
                }

                // Gửi trả lại nghĩa tiếng Việt tương ứng cho ứng dụng B
                byte[] sendBytes = Encoding.UTF8.GetBytes(vietnameseMeaning);
                server.Send(sendBytes, sendBytes.Length, endPoint);

                // Hiển thị kết quả trả về lên listBox1
                if (englishWord == "Hello")
                {
                    Invoke(new Action(() =>
                    {
                        listBox1.Items.Add($"{englishWord}");
                    }));
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        listBox1.Items.Add($"{englishWord} is {vietnameseMeaning}");
                    }));

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
