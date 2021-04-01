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

        public CommandManager(int userId, MySQLConnector connector)
        {
            this.connector = connector;
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

        public void createCommand(string quantity)
        {
            connector.Connect();
            string request = "INSERT INTO commandesencours values('"+this.userId + "','','" + quantity +"')";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            connector.Disconnect();
        }

        public void deleteCommand(int commandId)
        {
            connector.Connect();
            string request = "Delete * from commandesencours where IdCommande='" + commandId + "'";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
        }

        public List<string> getCommandList()
        {
            connector.Connect();
            string request = "select Quantite,IdCommande from commandesencours WHERE idUser='" +userId +"'";
            List<string> commandList = new List<string>();
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                commandList.Add(reader[0].ToString() + ":" + reader[1].ToString() +"<br/>");
            }
            connector.Disconnect();
            return commandList;

        }

      



    }
}