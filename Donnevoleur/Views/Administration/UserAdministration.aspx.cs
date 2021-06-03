using Donnevoleur.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donnevoleur.Views.Administration
{
    public partial class UserAdministration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
                SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
                Msg.Text = userObject.getAdminUserNameSelected();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserCommand.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHistory.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
            UserManager userManager = new UserManager(userObject.connector);
            userManager.DelUser(userObject.adminUserIdSelected);
        }
    }
}