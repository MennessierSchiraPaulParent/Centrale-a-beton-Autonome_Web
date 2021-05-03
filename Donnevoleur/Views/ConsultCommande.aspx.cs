using Donnevoleur.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donnevoleur.Views
{
    public partial class ConsultCommande : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
            CommandManager commandManager = new CommandManager(Int32.Parse(userObject.getUserID()), userObject.connector);

            List<string> list = commandManager.getCommandList();
            foreach(string listdisplay in list)
            {
                Msg.Text += listdisplay +"<br>";
            }
        }
    }
}