using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chattingServer
{
    internal class AddFunc
    {
        private static DBManager instance = new DBManager();
        public static DBManager GetInstance() { return instance; }
        string strconn = "server=115.85.181.212; Database=s5645730; Uid=s5645730; Pwd=s5645730; Charset=utf8";
        
        private DBManager() { }

        public void InsertOrUpdate(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public ArrayList Select(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                ArrayList readedData = new ArrayList();

                while (rdr.Read())
                {
                    readedData.Add(rdr.GetString(0));
                }
                return readedData;
            }
        }
        public int SelectNum(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                int readedData = 0;

                while (rdr.Read())
                {
                    readedData = Convert.ToInt32(rdr.GetString(0));
                }
                return readedData;
            }
        }
    }
}
