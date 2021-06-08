using Donnevoleur.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Donnevoleur.Views
{
    public partial class ConsultCommande : System.Web.UI.Page
    {
        CommandManager commandManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            string referer = Request.UrlReferrer.ToString();
            ButtonGenerate button = new ButtonGenerate();
            button.createReturn(referer);
            DynButton.Text = button.getButton();
            button.createHomeUser();
            DynButton2.Text = button.getButton();

            SessionObject userObject = (SessionObject)HttpContext.Current.Session["ID"];
            commandManager = new CommandManager(Int32.Parse(userObject.getUserID()), userObject.connector);

            List<string> list = commandManager.getCommandList();
            
         
            foreach (string listdisplay in list)
            {
                CheckBoxList2.Items.Add(listdisplay);
            }
        }
        protected void Validate_click(object sender, EventArgs e)
        {
            System.Drawing.Image image = null;
            BarCodeGenerator barcode;
            int idCommande = 0;
            foreach (ListItem item in CheckBoxList2.Items)
            {
                if (item.Selected)
                {
                    idCommande = Int32.Parse(item.Text.Substring(item.Text.IndexOf(":") + 1));
                    int test = (int)commandManager.getBarCode(idCommande);
                    barcode = new BarCodeGenerator(commandManager.getBarCode(idCommande));
                    image = barcode.barcodeImage;

                }
            }

            Response.Clear();
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", "attachment; filename=downloadedFile.png");
            byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(image, typeof(byte[]));
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Redirect("ConsultCommande.aspx");
        }
    }
}