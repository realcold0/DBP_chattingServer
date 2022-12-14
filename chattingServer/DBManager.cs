using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chattingServer
{
    internal class DBManager
    {
        private static DBManager instance = new DBManager();
        public static DBManager GetInstance() { return instance; }
        string strconn = "server=210.125.31.235; Port=443; Database=team6; Uid=team6; Pwd=dbpteam6; Charset=utf8";
        
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
        public List<string> Select(string query)
        {
            using (MySqlConnection conn = new MySqlConnection(strconn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<string> readedData = new List<string>();

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
