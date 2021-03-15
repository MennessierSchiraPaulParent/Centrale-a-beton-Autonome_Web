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
            databaseString = "Server=" + ipServer + ";User ID=" + user + ";Password=" + password + ";Database=" +
                             database;
        }

        public bool MySQLCheckLogin(string login, string password)
        {
            Connect();
            string request = "Select * from utilisateur where login=" + login + " and password=" + password;
            MySqlCommand cmd = new MySqlCommand(request, db);
            MySqlDataReader reader = cmd.ExecuteReader();
            string verif = login + password;
            reader.Read();
            string verifbdd = reader[0] + "" + reader[1];
            if (verif.Equals(verifbdd))
            {
                Disconnect();
                return true;
            }
            Disconnect();
            return false;

        }

        public MySQLConnector()
        {
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

        public void PremierTest()
        {
            Connect();

            Console.WriteLine("Première statement test :");
            string statement = "SELECT * FROM commandes";
            MySqlCommand cmd = new MySqlCommand(statement, db);
            MySqlDataReader reader = cmd.ExecuteReader();


            int i = 0;
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + "" + reader[1] + " " + reader[2] + " " + reader[3]);
                i++;
            }


            Disconnect();
        }


        public void CheckDriverUID(string id)
        {
            Connect();

            string statement = "SELECT * FROM commandes WHERE UID =" + id;
            MySqlCommand cmd = new MySqlCommand(statement, db);
            MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                Console.WriteLine("ID Correct");
            }
            else
            {
                Console.WriteLine("Fake ID");
            }

            Disconnect();
        }
    }
}