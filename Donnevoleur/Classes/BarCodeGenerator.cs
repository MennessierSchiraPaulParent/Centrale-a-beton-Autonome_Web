using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Donnevoleur.Classes
{
    public class BarCodeGenerator
    {
        public BarCodeGenerator()
        {

        }
        public Image BuildBarCode(int idCommande)
        {
            Barcode b = new Barcode();
            Image img = b.Encode(BarcodeLib.TYPE.EAN13, GenerateBareCode(idCommande) , Color.Black, Color.White, 290, 120);
            return img;

        }
        public string GenerateBareCode(int idCommande)
        {
            Random rd = new Random();
            
            double randomRange2 = Math.Pow(10, (12 - Math.Floor(Math.Log10(idCommande) + 1)));
            double code = Math.Abs(rd.NextDouble() * (randomRange2 - 0) + 0);

            return String.Format("{0:00}", code) + idCommande.ToString();
        }

    }
}