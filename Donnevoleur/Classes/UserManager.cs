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

        public bool ValidateUser(string login, string password)
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
        public bool ValidateAdmin(string login, string password)
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
            string request = "INSERT into utilisateurs values('"+login+"','"+password+"','')";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            connector.Disconnect();
        }
        public void DelUser(int idUser)
        {
            connector.Connect();
            string request1 = "delete * from utilisateurs where idUser = '" + idUser + "'";
            string request2 = "delete * from historiquecommandes where idUser = '" + idUser + "'";
            string request3 = "delete * from commandesencours where idUser = '" + idUser + "'";
            List<MySqlCommand> cmdList = new List<MySqlCommand>();
            cmdList.Add(new MySqlCommand(request1, connector.db));
            cmdList.Add(new MySqlCommand(request2, connector.db));
            cmdList.Add(new MySqlCommand(request3, connector.db));

            MySqlDataReader reader;
            foreach(MySqlCommand command in cmdList)
            {
               reader = command.ExecuteReader();   
            }
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
                //userList.Add("<input type =\"button\" value = \" "+ reader[0].ToString() +" "+ reader[1].ToString()+"\"/><br/>");
                userList.Add(reader[0].ToString() +":"  + reader[1].ToString());
            }
            return userList;
        }
    }
}