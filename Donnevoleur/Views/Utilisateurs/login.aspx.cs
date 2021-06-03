using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Donnevoleur.Classes;
using MySql.Data.MySqlClient;
using System.Data;

namespace Donnevoleur
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Login_Click(object sender, EventArgs e)
        {

            //Utilisé pour initialiser seulement 2 fois le MysSQLConnector
            UserManager usermanager = new UserManager(new MySQLConnector());
            //Permet de passer un objet dans la session afin de pouvoir le récupérer dans les différentes pages
            object userSessionParametersObject = new SessionObject(usermanager.GetUserID(UserName.Text,UserPass.Text),UserName.Text);
            //Objet dans un dictionnaire avec un id nommé "ID"
            HttpContext.Current.Session.Add("ID", userSessionParametersObject);

            if (usermanager.validateUserType(UserName.Text, UserPass.Text,"user"))
            {
                Response.Redirect("command.aspx");
            }
            else if(usermanager.validateUserType(UserName.Text, UserPass.Text,"admin"))
            {
                Response.Redirect("../Administration/adminPannel.aspx");
            }
            else
            {
                Msg.Text = "Invalid User Name and/or Password";
            }
        }
    }
}