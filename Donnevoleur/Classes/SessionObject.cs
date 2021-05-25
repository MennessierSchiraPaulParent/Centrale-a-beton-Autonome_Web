using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donnevoleur.Classes
{
    public class SessionObject
    {
        private int userID;
        private string userName;
        public MySQLConnector connector;
        public int adminUserIdSelected;
        public string adminUserNameSelected;
        //Rajouter des trucs a passer en paramètre
        public SessionObject(int userID, string userName)
        {
            this.userID = userID;
            this.userName = userName;
            this.connector = new MySQLConnector();
        }
        public string getUserID()
        {
            return userID.ToString();
        }

        public string getUserName()
        {
            return userName;
        }
        public int getAdminUserIdSelected()
        {
            return adminUserIdSelected;
        }

        /*public void setAdminUserIdSelected(string id)
        {
            adminUserIdSelected = Int32.Parse(id); 
        }

        public void setAdminUserNameSelected(string name)
        {
            adminUserNameSelected = name;
        }*/
        public string getAdminUserNameSelected()
        {
            return adminUserNameSelected;
        }
    }
}