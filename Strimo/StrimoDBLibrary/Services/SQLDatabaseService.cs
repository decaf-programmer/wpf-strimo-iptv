using StrimoDBLibrary.Models;
using StrimoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoDBLibrary.Services
{
    public static class SQLDatabaseService
    {

        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


        public static void CreateDBFile()
        {
            if (!File.Exists("StrimoDB.db3"))
            {
                SQLiteConnection.CreateFile("StrimoDB.db3");
            } 
        }

        public static void CreateUserTable()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=StrimoDB.db3;Version=3;");
            if (m_dbConnection.State == System.Data.ConnectionState.Closed)
                m_dbConnection.Open();

            if (!CheckIfTableExists("User"))
            {
                using(SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
                {
                    cmd.CommandText = "create table User(username varchar(30), password varchar(30), loginStatus int, lastLoginDate varchar(30))";
                    cmd.ExecuteNonQuery();
                }
            }

            if (m_dbConnection.State == System.Data.ConnectionState.Open)
            {
                m_dbConnection.Close();
            }
        }

        private static bool CheckIfTableExists(string tableName)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=StrimoDB.db3;Version=3;");
            if (m_dbConnection.State == System.Data.ConnectionState.Closed)
                m_dbConnection.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='{tableName}';";
                object result = cmd.ExecuteScalar();
                int resultCount = Convert.ToInt32(result);
                if (resultCount > 0)
                    return true;
            }

            if (m_dbConnection.State == System.Data.ConnectionState.Open)
            {
                m_dbConnection.Close();
            }

            return false;
        }

        public static void RegisterUser(string username, string password, int loginStatus, string currentTime)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=StrimoDB.db3;Version=3;");
            if (m_dbConnection.State == System.Data.ConnectionState.Closed)
                m_dbConnection.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = $"insert into User(username, password, loginStatus, lastLoginDate) values('{username}', '{password}', {loginStatus}, '{currentTime}')";
                cmd.ExecuteNonQuery();
            }

            if (m_dbConnection.State == System.Data.ConnectionState.Open)
            {
                m_dbConnection.Close();
            }
        }

        public static void UpdateUser(string username, string password, int loginStatus, string currentTime)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=StrimoDb.db3;Version=3");
            if (m_dbConnection.State == System.Data.ConnectionState.Closed)
                m_dbConnection.Open();

            using(SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = $"SELECT count(*) FROM User WHERE username='{username}'";
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if(count == 0)
                {
                    cmd.CommandText = $"insert into User(username, password, loginStatus, lastLoginDate) values('{username}', '{password}', {loginStatus}, '{currentTime}')";
                    cmd.ExecuteNonQuery();
                } else
                {
                    cmd.CommandText = $"Update User set username='{username}', password='{password}', loginStatus='{loginStatus}', lastLoginDate='{currentTime}' where username='{username}'";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<SQLUserModel> GetLastUsers()
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=StrimoDb.db3;Version=3");
            if(m_dbConnection.State == System.Data.ConnectionState.Closed)
            {
                m_dbConnection.Open();
            }

            SQLiteCommand command = new SQLiteCommand("Select * from User where loginStatus='1' ORDER BY lastLoginDate", m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<SQLUserModel> users = new List<SQLUserModel>();

            while (reader.Read())
            {
                SQLUserModel temp = new SQLUserModel();
                temp.username = (string)reader["username"];
                temp.password = (string)reader["password"];
                temp.loginStatus = (int)reader["loginStatus"];
                temp.lastLoginDate = (string)reader["lastLoginDate"];

                users.Add(temp);
            }

            reader.Close();
            m_dbConnection.Close();

            return users;
        }


        private static bool CheckIfColumnExists(string tableName, string columnName)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=StrimoDB.db3;Version=3;");
            if (m_dbConnection.State == System.Data.ConnectionState.Closed)
                m_dbConnection.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(m_dbConnection))
            {
                cmd.CommandText = string.Format("PRAGMA table_info({0})", tableName);

                var reader = cmd.ExecuteReader();
                int nameIndex = reader.GetOrdinal("Name");
                while (reader.Read())
                {
                    if (reader.GetString(nameIndex).Equals(columnName))
                    {
                        return true;
                    }
                }
            }

            if (m_dbConnection.State == System.Data.ConnectionState.Open)
            {
                m_dbConnection.Close();
            }
            return false;
        }
    }
}
