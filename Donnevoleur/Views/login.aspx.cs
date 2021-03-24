using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

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
            
            if (usermanager.ValidateUser(UserName.Text, UserPass.Text))
            {
                //Regarder a quoi sert le FormsAuth
                //FormsAuthentication.RedirectFromLoginPage(UserName.Text, chkboxPersist.Checked);
                Response.Redirect("command.aspx?parameter1="+ UserName.Text +"&parameter2=" + usermanager.GetUserID(UserName.Text, UserPass.Text));
            }
            else
            {
                Msg.Text = "Invalid User Name and/or Password";
            }
        }
    }
}