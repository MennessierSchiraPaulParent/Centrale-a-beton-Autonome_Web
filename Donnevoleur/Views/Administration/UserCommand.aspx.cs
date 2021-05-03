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
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
            CommandManager commandManager = new CommandManager(userObject.getAdminUserIdSelected(), userObject.connector);
            List<string> commands = commandManager.getCommandList();
            foreach(string s in commands)
            {
                CheckBoxList1.Items.Add(s);
            }
        }

        protected void Validate_click(object sender, EventArgs e)
        {
            /*List<ListItem> selected = new List<ListItem>();*/
            foreach(
                ListItem item in CheckBoxList1.Items)
            {

                
               /* selected.Add(item);*/
            }


        }
    }


}