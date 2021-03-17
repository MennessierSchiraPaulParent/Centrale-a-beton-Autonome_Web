using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Donnevoleur
{
    public class MySQLConnector
    {
        private string ipServer;
        private string database;
        private string user;
        private string password;
        private string databaseString;
        private MySqlConnection db;

        public MySQLConnector(string ipServer, string database, string user, string password)
        {
            this.ipServer = ipServer;
            this.database = database;
            this.user = user;
            this.password = password;
            databaseString = "Server=" + ipServer + ";User ID=" + user + ";Password=" + password + ";Database=" + database;
        }

        public MySQLConnector()
        {
            databaseString = "Server=localhost;User ID=root;Password=;Database=juif";
        }
        private void Connect()
        {
            try
            {
                db = new MySqlConnection(databaseString);
                db.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void Disconnect()
        {
            db.Close();
        }

        public bool MySQLCheckLogin(string login, string password)
        {
            Connect();
            string request = "SELECT * from utilisateurs where login='" + login + "' and password='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(request, db);
            MySqlDataReader reader = cmd.ExecuteReader();


            string verif = login + password;
            string verifbdd = "";
            if (reader.Read())
            {
                verifbdd = reader[0] + "" + reader[1];
            }

            if (verif.Equals(verifbdd))
            {
                Disconnect();
                return true;
            }
            Disconnect();
            return false;
        }

        //Plus tard faire un tableau avec un renvoie du boolean et de la valeur id

        public int MySQLUserId(string login, string password)
        {
            Connect();
            string request = "SELECT * from utilisateurs where login='" + login + "' and password='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(request, db);
            MySqlDataReader reader = cmd.ExecuteReader();


            int id = 0;
            if (reader.Read())
            {
              id = (int)reader[2];
            }
            Disconnect();
            return id;
        }
        
        public int MySQLCommandID(string userid)
        {
            Connect();
            string request = "SELECT * from command_id where UserId='" +userid  + "'";
            MySqlCommand cmd = new MySqlCommand(request, db);
            MySqlDataReader reader = cmd.ExecuteReader();

            int id = 0;
            if (reader.Read())
            {
                id = (int)reader[1];
            }
            Disconnect();
            return id;

        }




    }
}