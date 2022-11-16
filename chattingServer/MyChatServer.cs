using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace chattingServer
{
    class MyChatServer
    {
        static Dictionary<string, TcpClient> userData = new Dictionary<string, TcpClient>();
        TcpClient client;
        NetworkStream stream = default(NetworkStream);
        string userID;
        ChatServerForm serverForm; 
        public MyChatServer(TcpClient client, string userID, ChatServerForm serverForm)
        {
            this.userID = userID;
            this.client = client;
            this.serverForm = serverForm;
            userData.Add(userID, client);
            serverForm.AddText(string.Format($"[{userID}] connected to server.\r\n"));
            Broadcast(string.Format("{0} joined to server", userID), "Notice");
            Thread refresher = new Thread(Refresh);
            refresher.IsBackground = true;
            refresher.Start();
        }
        void Refresh()
        {
            while (true)
            {
                if (!client.Connected) break;
                byte[] bytes = Encoding.Default.GetBytes(serverForm.bufferedList);
                 stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                Thread.Sleep(1000);
            }

        }
        void Broadcast(string msg, string ID)
        {
            foreach (var user in userData)
            {
                TcpClient client = user.Value as TcpClient;
                stream = client.GetStream();
                byte[] buffer = Encoding.Default.GetBytes(string.Format("{0} {1}", ID, msg));
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
        }
        bool Controller(string str)
        {
            bool isControlMsg = true;
            if (str.Equals("/exit"))
            {
                serverForm.users.Remove(userID);
                Broadcast(string.Format($"{userID} exited"), "Notice");
                userData.Remove(userID);
            }
            else
            {
                isControlMsg = false;
            }
            return isControlMsg;
        }
        public void Listen()
        {
            NetworkStream stream = client.GetStream();
            try
            {
                while (true)
                {
                    int bufLength;
                    byte[] buffer = new byte[1024];
                    string str = string.Empty;
                    if (!client.Connected) break;
                    try
                    {
                        while ((bufLength = stream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            str = Encoding.Default.GetString(buffer, 0, bufLength);
                            serverForm.AddText(string.Format($"{userID} {str}\r\n"));
                            if (!Controller(str)) Broadcast(str, userID);
                        }
                    }
                    catch (IOException e)
                    {
                    }

                }
            }
            catch (SocketException e)
            {
                serverForm.AddText(string.Format("{0} 클라이언트 오류로 인한 퇴장\r\n", userID));
                stream.Close();
                client.Close();
            }
            finally
            {
                serverForm.AddText(string.Format("{0} 클라이언트 퇴장\r\n", userID));
                stream.Close();
                client.Close();
            }


        }
    }
}
