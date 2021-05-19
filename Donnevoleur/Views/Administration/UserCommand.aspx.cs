using Donnevoleur.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donnevoleur.Views.Administration
{
    public partial class UserCommand : System.Web.UI.Page
    {
        SessionObject userObject;
        CommandManager commandManager;
        List<string> commands = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckBoxList1.Items.Clear();
            userObject = (SessionObject)HttpContext.Current.Session["ID"];
            commandManager = new CommandManager(userObject.getAdminUserIdSelected(), userObject.connector);
            commands = commandManager.getCommandList();
            foreach(string s in commands)
            {
                CheckBoxList1.Items.Add(s);
            }
            commands.Clear();
        }
        protected void Validate_click(object sender, EventArgs e)
        {
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    commandManager.deleteCommand(Int32.Parse(item.Text.Substring(item.Text.IndexOf(":") + 1)));
                }
            }
        }
    }
}