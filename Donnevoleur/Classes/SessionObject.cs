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
        //Rajouter des trucs a passer en paramètre
        public SessionObject(int userID, string userName)
        {
            this.userID = userID;
            this.userName = userName;
        }

        public string getUserID()
        {
            return userID.ToString();
        }

        public string getUserName()
        {
            return userName;
        }
    }
}