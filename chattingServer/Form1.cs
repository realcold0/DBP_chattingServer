using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Utilities.Collections;
using System.Xml.Linq;
using System.Collections;

namespace chattingServer
{
    public partial class ChatServerForm : Form
    {
        public string bufferedList;
        public List<string> users = new List<string>();
        static Dictionary<string, TcpClient> userDataDict = new Dictionary<string, TcpClient>();
        TcpListener server;
        public string noticeMsg;

        public void AddText(string text)
        {
            myConsole.AppendText(text);
            myConsole.Select(myConsole.Text.Length, 0);
            myConsole.ScrollToCaret();
            AddFunc addFunc = new AddFunc(this);
            addFunc.InsertMsg(text);// 변경(영주)_mysql insert
        }
        /*
        void ControlEnter(object sender, EventArgs e)
        {
            string input = ControlInput.Text;
            Controller(input);
            ControlInput.Text = string.Empty;
            ControlInput.Focus();
        }*/

        void RefreshChatters()
        {
            CheckForIllegalCrossThreadCalls = false;
            while (true)
            {
                bufferedList = "**userlist** ";
                ClientList.Items.Clear();
                foreach (string user in users)
                {
                    ClientList.Items.Add(user);
                    bufferedList += (user + " ");
                }
                Thread.Sleep(1000);
            }
        }

        void OpenServer()
        {
            TcpClient client = new TcpClient();
            const int Port = 443;
            IPEndPoint serverAddr = null;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    serverAddr = new IPEndPoint(IPAddress.Parse(ip.ToString()), Port);
                    //DB에 서버 ip 입력하기
                    string query = "update ServerInfo set ServerIP='" + ip.ToString() + "' where ID='server'";
                    DBManager.GetInstance().InsertOrUpdate(query);
                    //
                    break;
                }
            }
            server = new TcpListener(serverAddr);
            try
            {
                server.Start();
            }
            catch (SocketException e)
            {
                MessageBox.Show("올바르지 않은 주소입니다.");
                return;
            }
            AddText(String.Format("Server Opened. [{0}]\r\n", serverAddr.ToString()));
            while (true)
            {
                try
                {
                    client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string userID = Encoding.UTF8.GetString(buffer, 0, bytes);
                    users.Add(userID);
                    MyChatServer mychat = new MyChatServer(client, userID, this);
                    userDataDict = mychat.getUserData();
                    Thread serverThread = new Thread(new ThreadStart(mychat.Listen));
                    serverThread.IsBackground = true;
                    serverThread.Start();
                }
                catch (Exception e) { break; }
            }
            client.Close();
            server.Stop();
        }
        void CloseServer()
        {
            // 서버 닫는 처리
        }
        /*
        void Controller(string s)
        {
            if (s.Equals(string.Empty)) return;
            else if (s.Equals("/close"))
            {
                CloseServer();
                AddText("[Server] Closed.\r\n");
                //state = false;
            }
            else if (s.StartsWith("/open "))
            {
                //state = true;

                Thread open = new Thread(OpenServer);
                //string query = string.Format("update Server set IP = '{0}' where id = 1;", s); // 변경 - IP주소 query에 update
                //DBManager.GetInstance().InsertOrUpdate(query); // 변경
                open.IsBackground = true;
                open.Start(s);
            }
        }*/
        public ChatServerForm()
        {
            InitializeComponent();
        }

        /*
        private void ControlInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) ControlEnter(sender, e);
        }*/

        private void ChatServerForm_Load(object sender, EventArgs e)
        {
            Thread refresher = new Thread(RefreshChatters);
            refresher.IsBackground = true;
            refresher.Start();
            Thread open = new Thread(OpenServer);
            //string query = string.Format("update Server set IP = '{0}' where id = 1;", s); // 변경 - IP주소 query에 update
            //DBManager.GetInstance().InsertOrUpdate(query); // 변경
            open.IsBackground = true;
            open.Start();
        }

        private void SendNoticeAll_Func(object sender, EventArgs e)
        {
            noticeMsg = textBox1.Text;

            NetworkStream stream = default(NetworkStream);

            foreach (var user in userDataDict)
            {
                TcpClient client = user.Value as TcpClient;
                stream = client.GetStream();
                byte[] buffer = Encoding.Default.GetBytes(string.Format("{0} {1}", "server", noticeMsg));
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }

        private void SendNoticeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) SendNoticeAll_Func(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CloseServer();
            AddText("[Server] Closed.\r\n");
        }
    }
}