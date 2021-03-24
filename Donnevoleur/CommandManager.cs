using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace Donnevoleur
{

    public class CommandManager
    {
        MySQLConnector connector;
        int userId;
        
        public CommandManager(int userId)
        {
            this.connector = new MySQLConnector();
            this.userId = userId;
        }

        public int getCommandID()
        {
            connector.Connect();
            string request = "SELECT * from commandeencours where IdUser='" + this.userId + "'";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
                
            int id = 0;
            if (reader.Read())
            {
                id = (int)reader[1];
            }
            connector.Disconnect();
            return id;
        }


    }
}