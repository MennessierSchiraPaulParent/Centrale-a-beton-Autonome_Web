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
    public partial class creerCommande : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void CommandCreate_Click(object sender, EventArgs e)
        {
            BarCodeGenerator barCodeGenerator = new BarCodeGenerator();
            SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
            CommandManager commandManager = new CommandManager(Int32.Parse(userObject.getUserID()), userObject.connector);
            commandManager.createCommand(Quantity.Text);
            //Création du code barre rattaché a la commande
            int lastOrder = commandManager.getLastCommand(Int32.Parse(userObject.getUserID()));
            Msg.Text = lastOrder.ToString();
            //barCodeGenerator.BuildBarCode(lastOrder);
            
            /*Response.ContentType = "image/jpeg";
            Response.AppendHeader("Content-Disposition", "attachment; filename=commandNumber"+lastOrder+".png");
            Response.TransmitFile(Server.MapPath("~/commandNumber"+lastOrder+".png"));
            Response.End();
            Response.Redirect("command.aspx");*/
        }
    }
}