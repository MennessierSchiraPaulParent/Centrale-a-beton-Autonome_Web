using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Donnevoleur.Classes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

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
            int lastOrder = commandManager.getLastCommand(Int32.Parse(userObject.getUserID()));
            commandManager.createCommandBarCode(barCodeGenerator.GenerateBareCode(lastOrder));
            
            //Création du code barre rattaché a la commande
            
            Msg.Text = lastOrder.ToString();

            System.Drawing.Image image = barCodeGenerator.BuildBarCode(lastOrder);
            
            Response.Clear();
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", "attachment; filename=downloadedFile.png");
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(image, typeof(byte[]));
            Response.BinaryWrite(bytes);
            Response.End();

        }
    }
}