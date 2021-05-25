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
        public MySqlConnection db;

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
            databaseString = "Server=centrale;User ID=install;Password=install;Database=centrale_beton";
            //databaseString = "Server=localhost;User ID=root;Password=;Database=centrale_beton";
        }
        public void Connect()
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
        public void Disconnect()
        {
            db.Close();
        }
    }
}