using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donnevoleur
{
    public partial class welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request.QueryString["parameter1"];
            string id = Request.QueryString["parameter2"];

            CommandManager commandManager = new CommandManager(Int32.Parse(id));
        }
    }
}