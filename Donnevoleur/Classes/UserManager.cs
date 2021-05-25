using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Donnevoleur
{
    public class UserManager
    {
        
        MySQLConnector connector;
        public UserManager(MySQLConnector connector)
        {
            this.connector = connector;
        }

        /*public bool validateUser(string login, string password)
        {
            connector.Connect();
            string request = "SELECT * from utilisateurs where Login='" + login + "' and Password='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();

            string verif = login + password;
            string verifbdd = "";
            if (reader.Read())
            {
                verifbdd = reader[0] + "" + reader[1];
            }

            if (verif.Equals(verifbdd))
            {
                connector.Disconnect();
                return true;
            }
            connector.Disconnect();
            return false;
        }
        public bool validateAdmin(string login, string password)
        {
            connector.Connect();
            string request = "Select * from administrateurs where Login='" + login + "' and Password='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            string verif = login + password;
            string verifbdd = "";

            if (reader.Read())
            {
                verifbdd = reader[0] + "" + reader[1];
            }

            if (verif.Equals(verifbdd))
            {
                connector.Disconnect();
                return true;
            }
            connector.Disconnect();
            return false;
        }*/



        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="type1 for user / type 2 for admin"></param>
        /// <returns></returns>
        public bool validateUserType(string login, string password, string type)
        {
            connector.Connect();
            string request = "";
            string verif = login + password;
            string verifbdd = "";
            if (type.Equals("user"))
            {
                request = "SELECT * from utilisateurs where Login='" + login + "' and Password='" + password + "'";
            }
            else if(type.Equals("admin"))
            {
                request = "Select * from administrateurs where Login='" + login + "' and Password='" + password + "'";
            }
            
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                verifbdd = reader[0] + "" + reader[1];
            }

            if (verif.Equals(verifbdd))
            {
                connector.Disconnect();
                return true;
            }
            connector.Disconnect();
            return false;
        }
        
        public int GetUserID(string login, string password)
        {

            connector.Connect();
            string request = "SELECT * from utilisateurs where Login='" + login + "' and Password='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();

            int id = 0;
            if (reader.Read())
            {
                id = (int)reader[2];
            }
            connector.Disconnect();
            return id;
        }
        public void CreateUser(string login, string password)
        {
            connector.Connect();
            string request = "INSERT into utilisateurs(Login,Password) values('"+login+"','"+password+"')";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            connector.Disconnect();
        }
        public void DelUser(int idUser)
        {
            connector.Connect();
            string request = "delete from utilisateurs where idUser = '" + idUser + "';" +
                "delete from historiquecommandes where idUser = '" + idUser + "';" +
                "delete from commandesencours where idUser = '" + idUser + "'";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            connector.Disconnect();
        }

        public List<string> GetUserList()
        {
            connector.Connect();
            string request = "select Login, idUser from utilisateurs";
            List<string> userList = new List<string>();
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userList.Add(reader[0].ToString() +":"  + reader[1].ToString());
            }
            connector.Disconnect();
            return userList;
        }
    }
}