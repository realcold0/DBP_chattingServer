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
            AddFunc addFunc = new AddFunc(this);
            addFunc.InsertMsg(text);// ����(����)_mysql insert
        }
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
                MessageBox.Show("�ùٸ��� ���� �ּ��Դϴ�.");
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
            // ���� �ݴ� ó��
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
                //string query = string.Format("update Server set IP = '{0}' where id = 1;", s); // ���� - IP�ּ� query�� update
                //DBManager.GetInstance().InsertOrUpdate(query); // ����
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