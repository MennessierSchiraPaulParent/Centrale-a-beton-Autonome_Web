using Donnevoleur.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donnevoleur
{
    public partial class command : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonGenerate button = new ButtonGenerate();
            button.createDisconnect();
            DynButton.Text = button.getButton();
        }
        protected void Disconnect(object sender, EventArgs e)
        {

        }
    }
}