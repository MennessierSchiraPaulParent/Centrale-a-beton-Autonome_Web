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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Click(object sender, EventArgs e)
        {

            UserManager usermanager = new UserManager();

            object userSessionObject = new SessionObject(usermanager.GetUserID(UserName.Text,UserPass.Text),UserName.Text);
            HttpContext.Current.Session.Add("ID", userSessionObject);

            if (usermanager.ValidateUser(UserName.Text, UserPass.Text))
            {
                //Regarder a quoi sert le FormsAuth
                //FormsAuthentication.RedirectFromLoginPage(UserName.Text, chkboxPersist.Checked);
                Response.Redirect("command.aspx");
            }
            else
            {
                Msg.Text = "Invalid User Name and/or Password";
            }
        }
    }
}