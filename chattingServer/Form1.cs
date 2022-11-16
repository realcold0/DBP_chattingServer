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
        TcpListener server;
        public void AddText(string text)
        {
            myConsole.AppendText(text);
            myConsole.Select(myConsole.Text.Length, 0);
            myConsole.ScrollToCaret();
            // InsertMsg(text);// 변경 중... mysql insert
        }
        /*
        public void InsertMsg(string text)
        {
            string[] strings = text.Split(" ");
            int len = strings[0].Length + strings[1].Length + 1;
            string subSTR = text.Substring(0, len);
            string From = strings[0][1..-1];
            string To = strings[1][1..-1];
            string msg = text.Replace(subSTR, "");
            string findquery = string.Format("SELECT IFNULL(MAX(채팅방목록.보낸유저), 'NULL') AS 결과 " +
                "FROM 채팅방목록 where 보낸유저 like '{0}' AND 받는유저 like '{1}';", From, To);
            ArrayList result = new ArrayList(DBManager.GetInstance().Select(findquery));
            if (result[0] != "NULL")
            {
                int num = DBManager.GetInstance().SelectNum("select count(보낸유저) from 채팅방목록;");
                string insertquery = string.Format("insert into 채팅방목록 (보낸유저, 받는유저, 채팅방ID) " +
                    "values('{0}', '{1}', {2})", From, To, num);
                DBManager.GetInstance().InsertOrUpdate(insertquery);
            }
            
             
        }
        */
        void ControlEnter(object sender, EventArgs e)
        {
            string input = ControlInput.Text;
            Controller(input);
            ControlInput.Text = string.Empty;
            ControlInput.Focus();
        }
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
        void OpenServer(object s)
        {
            string serverIP = s.ToString().Substring("/open ".Length);
            TcpClient client = new TcpClient();
            const int Port = 10203;
            IPEndPoint serverAddr = new IPEndPoint(IPAddress.Parse(serverIP), Port);
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
                    string userID = Encoding.Default.GetString(buffer, 0, bytes);
                    users.Add(userID);
                    MyChatServer mychat = new MyChatServer(client, userID, this);
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
        void Controller(string s)
        {
            if (s.Equals(string.Empty)) return;
            else if (s.Equals("/close"))
            {
                CloseServer();
                AddText("[Server] Closed.\r\n");
            }
            else if (s.StartsWith("/open "))
            {
                Thread open = new Thread(OpenServer);
                string query = string.Format("update Server set IP = '{0}' where id = 1;", s); // 변경 - IP주소 query에 update
                DBManager.GetInstance().InsertOrUpdate(query); // 변경
                open.IsBackground = true;
                open.Start(s);
            }
        }
        public ChatServerForm()
        {
            InitializeComponent();
        }

        private void ControlInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) ControlEnter(sender, e);
        }

        private void ChatServerForm_Load(object sender, EventArgs e)
        {
            Thread refresher = new Thread(RefreshChatters);
            refresher.IsBackground = true;
            refresher.Start();
        }
    }
}