using Donnevoleur.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            string referer = Request.UrlReferrer.ToString();
            ButtonGenerate button = new ButtonGenerate();
            button.createReturn(referer);
            DynButton.Text = button.getButton();
            button.createHomeAdmin();
            DynButton2.Text = button.getButton();

            userObject = (SessionObject)HttpContext.Current.Session["ID"];
            commandManager = new CommandManager(userObject.getAdminUserIdSelected(), userObject.connector);
            //commands.Clear();
            commands = commandManager.getCommandList();
            //CheckBoxList1.Items.Clear();
            foreach (string s in commands)
            {
                CheckBoxList1.Items.Add(s);
            }
        }

        protected void Validate_click(object sender, EventArgs e)
        {
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    //Int32.Parse(item.Text.Substring(item.Text.IndexOf(":") + 1))
                    commandManager.deleteCommand(Int32.Parse(item.Text.Substring(item.Text.IndexOf(":") + 1)));
                    //Oui.Text = item.Text.Substring(item.Text.IndexOf(":") + 1);
                }
            }
            //CheckBoxList1.ClearSelection();
            Response.Redirect("UserCommand.aspx");
        }
    }
}