using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chattingServer
{
    internal class AddFunc
    {
        Form ChatServerForm;
        public AddFunc(Form chatServerForm)
        {
            ChatServerForm = chatServerForm;
        }

        public void InsertMsg(string text) // 추가(영주)_mysql insert
        {
            string[] strings = text.Split(" ");
            int len = strings[0].Length + strings[1].Length + 1; // 지워야할 문자열의 인덱스
            string subSTR = text.Substring(0, len); // 지울 문자열
            string From = strings[0]; // 보낸사람
            string To = strings[1]; // 받는사람
            string msg = text.Replace(subSTR, ""); // 메시지
            string checkquery = string.Format("SELECT IFNULL(MAX(채팅방목록.보낸유저), 'NULL') AS 결과 " +
                "FROM 채팅방목록 where 보낸유저 like '{0}' AND 받는유저 like '{1}';", From, To); // 채팅방목록이 존재하는지 확인
            ArrayList result = new ArrayList(DBManager.GetInstance().Select(checkquery)); // 확인 결과
            if (result[0].ToString() == "NULL") // 채팅방 목록 없을 경우
                NoChatList(From, To); // 채팅방 목록 insert

            if (result[0].ToString() == From) // 채팅방 목록 있을 경우
                InsertChatList(From, To, text); // 메시지 insert
        }
        public void NoChatList(string From, string To)
        {
            string userquery = string.Format("SELECT IFNULL(MAX(회원정보.이름), 'NULL') AS 결과 " +
            "FROM 회원정보 where 이름 like '{0}';", To); // 받는사람이 회원정보에 있는지 확인
            ArrayList user = new ArrayList(DBManager.GetInstance().Select(userquery)); // 확인 결과
            if (user[0].ToString() != "NULL") // 회원정보에 존재할 경우
            {
                int num = DBManager.GetInstance().SelectNum("select count(보낸유저) from 채팅방목록;") + 1;
                string insertquery = string.Format("insert into 채팅방목록 (보낸유저, 받는유저, 채팅방ID) " +
                    "values('{0}', '{1}', {2})", From, To, num);
                DBManager.GetInstance().InsertOrUpdate(insertquery); // 채팅방목록 추가
            }
        }
        public void InsertChatList(string From, string To, string msg)
        {
            string chatnumquery = string.Format("select 채팅방ID from 채팅방목록 where 보낸유저 like '{0}' and 받는유저 like '{1}';", From, To);
            int chatnum = DBManager.GetInstance().SelectNum(chatnumquery); // 채팅방ID
            DateTime nowDate = DateTime.Now;
            string date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string chatquery = string.Format("insert into 채팅 (채팅방ID, 메시지내용, 채팅시간) values({0}, '{1}', '{2}');", chatnum, msg, date);
            DBManager.GetInstance().InsertOrUpdate(chatquery); // 채팅 추가
        }
    }
}
