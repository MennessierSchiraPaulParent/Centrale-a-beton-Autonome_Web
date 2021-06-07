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
            string referer = Request.UrlReferrer.ToString();
            ButtonGenerate button = new ButtonGenerate();
            button.createReturn(referer);
            DynButton.Text = button.getButton();

            SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
            CommandManager commandManager = new CommandManager(userObject.getAdminUserIdSelected(), userObject.connector);

            //Remplacer par l'historique (historyCommandList)
            List<string> commandList = commandManager.getHistoryList();

            foreach(string s in commandList)
            {
                Msg.Text += s + "<br>";
            }
        }
    }
}