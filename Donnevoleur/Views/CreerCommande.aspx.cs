using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Donnevoleur.Classes;

namespace Donnevoleur
{
    public partial class creerCommande : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void CommandCreate_Click(object sender, EventArgs e)
        {
            SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
            CommandManager commandManager = new CommandManager(Int32.Parse(userObject.getUserID()), userObject.connector);
            commandManager.createCommand(Quantity.Text);
            Response.Redirect("command.aspx");
        }
    }
}