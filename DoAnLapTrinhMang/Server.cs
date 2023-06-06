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
        private bool _connected = true;
        private UdpClient server;
        private IPEndPoint endPoint;
        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            { "Computer", "(Máy tính) <Máy tính là một thiết bị điện toán có khả năng nhận, lưu trữ và xử lý thông tin một cách hữu ích. Một máy tính được lập trình để thực hiện các hoạt động logic hoặc số học tự động>"},
            { "RAM", "(Bộ nhớ trong) <RAM (Random Access Memory) là một loại bộ nhớ khả biến cho phép đọc - ghi ngẫu nhiên dữ liệu đến bất kỳ vị trí nào trong bộ nhớ dựa theo địa chỉ của bộ nhớ. Tất cả mọi thông tin lưu trên RAM chỉ là tạm thời và chúng sẽ mất đi khi không còn nguồn điện cung cấp.>" },
            { "HDD", "(Ổ đĩa cứng) <là ổ cứng truyền thống, nguyên lý hoạt động cơ bản là có một đĩa tròn làm bằng nhôm (hoặc thủy tinh, hoặc gốm) được phủ vật liệu từ tính. Giữa ổ đĩa có một động cơ quay để đọc/ghi dữ liệu, kết hợp với những thiết bị này là những bo mạch điện tử nhằm điều khiển đầu đọc/ghi đúng vào vị trí của cái đĩa từ lúc nãy khi đang quay để giải mã thông tin>" }
        };

        public Server()
        {
            InitializeComponent();
            button2.Hide();
            InitServer();


        }

        private void InitServer()
        {
            server = new UdpClient(8088);
            endPoint = new IPEndPoint(IPAddress.Any, 8088);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            _connected = true;
            Task.Factory.StartNew(() => ListenForRequests());
            button1.Hide();
            button2.Show();
        }

        private void ListenForRequests()
        {
            while(_connected)
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _connected = false;
            button1.Show();
            button2.Hide();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            button1.Focus();
        }

        private void button_thoat_Click(object sender, EventArgs e)
        {
            server.Close();
            Application.Exit();
        }
    }
}
