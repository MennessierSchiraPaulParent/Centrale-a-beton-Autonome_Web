using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace Donnevoleur
{

    public class CommandManager
    {
        public MySQLConnector connector;
        public int userId;

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

        public void createCommandBarCode(string codeBar)
        {
            connector.Connect();
            //Bonne requete mon reuf
            int idCommande = 0;
            //string request = "update commandesencours set CodeBarre ="+codeBar+" where IdCommande = (Select MAX(IdCommande) from commandesencours where idUser = "+this.userId+")";
            string request = "Select MAX(IdCommande) from commandesencours where idUser = " + this.userId;
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                idCommande = Int32.Parse(reader[0].ToString());
            }
            request = "update commandesencours set CodeBarre =" + codeBar + " where IdCommande =" + idCommande;
            reader.Close();
            cmd = new MySqlCommand(request, connector.db);
            reader = cmd.ExecuteReader(); 
            connector.Disconnect();
        }
        public void createCommand(string quantity)
        {
            connector.Connect();
            //Bonne requete mon reuf
            string request = "INSERT INTO commandesencours (idUser,Quantite) values('" + this.userId + "','" + quantity +"')";
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            connector.Disconnect();
        }

        public void deleteCommand(int commandId)
        {
            connector.Connect();
            string request = "DELETE FROM `commandesencours` WHERE `commandesencours`.`IdCommande` ="+ commandId;
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            connector.Disconnect();
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
                commandList.Add(reader[0].ToString() + ":" + reader[1].ToString());
            }
            connector.Disconnect();
            return commandList;
        }
        public List<string> getHistoryList()
        {
            connector.Connect();
            string request = "select IdCommande,Quantite from historiquecommandes WHERE idUser='" + userId + "'";
            List<string> historyList = new List<string>();
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                historyList.Add(reader[0].ToString() + ":" + reader[1].ToString());
            }
            connector.Disconnect();
            return historyList;
        }
        public int getLastCommand(int idUser)
        {
            int commandNumber = 0;
            connector.Connect();
            string request = "SELECT MAX(IdCommande) FROM commandesencours where idUser ="+idUser.ToString();
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                commandNumber = Convert.ToInt32(reader[0]);
            }
            connector.Disconnect();
            return commandNumber;
        }
        
        public long getBarCode(int commandId)
        {
            string barcode ="";
            long final = 0;
            connector.Connect();
            string request = "SELECT CodeBarre FROM commandesencours WHERE idCommande =" + commandId;
            MySqlCommand cmd = new MySqlCommand(request, connector.db);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                barcode = reader[0].ToString();
                final  = Convert.ToInt64(barcode);
            }
            connector.Disconnect();
            return final;
        }
    }
}