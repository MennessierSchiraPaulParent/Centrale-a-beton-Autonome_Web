using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donnevoleur.Classes
{
    public class ButtonGenerate
    {
        string disconnectButton;
        public ButtonGenerate()
        {
            
        }

        public void createDisconnect()
        {
            this.disconnectButton = "<style>.valide {float:right;}</style > <div class=\"valide\"> <a href=\"Disconnect.aspx\" > <input type=\"button\"  value=\"Logout\"/></a></div>";
        }
        public void createReturn(string urlreturn)
        {
            this.disconnectButton = "<style>.valide {float:right;}</style > <div class=\"valide\"> <a href="+urlreturn +"> <input type=\"button\"  value=\"Back\"/></a></div>";
        }
        public string getButton()
        {
            return this.disconnectButton;
        }
    }
}