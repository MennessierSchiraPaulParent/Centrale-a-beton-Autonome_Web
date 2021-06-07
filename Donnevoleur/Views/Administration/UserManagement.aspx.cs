using Donnevoleur.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donnevoleur.Views.Administration
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SessionObject userObject;
        private UserManager userManager;
        private List<string> list;
        protected void Page_Load(object sender, EventArgs e)
        {

            string referer = Request.UrlReferrer.ToString();
            ButtonGenerate button = new ButtonGenerate();
            button.createReturn(referer);
            DynButton.Text = button.getButton();


            userObject = (SessionObject)HttpContext.Current.Session["ID"];
            userManager = new UserManager(userObject.connector);
            list = userManager.GetUserList();

            foreach (string listdisplay in list)
            {     
                UserList.Items.Add(listdisplay.Substring(0, listdisplay.IndexOf(":")));
            }

        }
        protected void Validate_click(object sender, EventArgs e)
        {
            int userListIndex = UserList.SelectedIndex;
            //Msg.Text = list[userListIndex].Substring(list[userListIndex].IndexOf(":")+1);
            userObject.setAdminUserIdSelected(list[userListIndex].Substring(list[userListIndex].IndexOf(":") + 1));
            userObject.setAdminUserNameSelected(list[userListIndex].Substring(0, list[userListIndex].IndexOf(":")));
            Response.Redirect("UserAdministration.aspx");
        }
    }
}