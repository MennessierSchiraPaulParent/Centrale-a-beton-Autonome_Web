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
            if (!string.IsNullOrEmpty(Request.QueryString["test"]))
            {
                // prefill your search textbox
                Msg.Text = Request.QueryString["test"];

                // run your code that does a search and fill your repeater/datagrid/whatever here
            }
        }
    }
}