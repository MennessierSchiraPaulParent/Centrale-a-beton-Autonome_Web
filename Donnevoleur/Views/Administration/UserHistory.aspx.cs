using Donnevoleur.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donnevoleur.Views.Administration
{
    public partial class UserHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
            CommandManager commandManager = new CommandManager(userObject.getAdminUserIdSelected(), userObject.connector);

            //Remplacer par l'historique (historyCommandList)
            List<string> commandList = commandManager.getCommandList();

            foreach(string s in commandList)
            {
               //faire les bails
            }
        }
    }
}