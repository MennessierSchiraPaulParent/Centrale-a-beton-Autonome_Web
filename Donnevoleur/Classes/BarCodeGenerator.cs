using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Donnevoleur.Classes
{
    public class BarCodeGenerator
    {
        public BarCodeGenerator()
        {

        }
        public void BuildBarCode(int idCommande)
        {
            Random rd = new Random();
            Barcode b = new Barcode();

            double randomRange2 = Math.Pow(10, (12 - Math.Floor(Math.Log10(idCommande) + 1)));
            double code = Math.Abs(rd.NextDouble() * (randomRange2 - 0) + 0);
            Image img = b.Encode(BarcodeLib.TYPE.EAN13, String.Format("{0:0}", code) + idCommande.ToString(), Color.Black, Color.White, 290, 120);

            img.Save("commandNumber.jpg");

        }
    }
}