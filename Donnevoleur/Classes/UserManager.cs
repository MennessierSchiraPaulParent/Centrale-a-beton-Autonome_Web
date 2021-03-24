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
        public UserManager()
        {
            this.connector = new MySQLConnector();
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

    }
}