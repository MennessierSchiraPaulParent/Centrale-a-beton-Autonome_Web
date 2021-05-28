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
        public string barcodecode;
        public Image barcodeImage;
        public string controlKeystr;
        public BarCodeGenerator(int idCommande)
        {
            Barcode b = new Barcode();
            this.barcodeImage = b.Encode(BarcodeLib.TYPE.EAN13, GenerateBareCode(idCommande), Color.Black, Color.White, 290, 120);
        }

        public string GenerateBareCode(int idCommande)
        {
            Random rd = new Random();
            
            double randomRange2 = Math.Pow(10, (12 - Math.Floor(Math.Log10(idCommande) + 1)));
            double code = Math.Abs(rd.NextDouble() * (randomRange2 - 0) + 0);
            this.controlKeystr = controlkey(idCommande, code).ToString();
            this.barcodecode = Math.Round(code, 0).ToString() + idCommande.ToString();
            return this.barcodecode;
        }
        public int controlkey(int reader, double code)
        {
            int cle = 0;
            bool un = true;
            code = Math.Round(code, 0);

            string chaineATraiter = code.ToString() + reader.ToString();

            foreach (char a in chaineATraiter)
            {
                if (un)
                {
                    cle += ((int)Char.GetNumericValue(a) * 1);
                    un = false;
                }
                else
                {
                    cle += ((int)Char.GetNumericValue(a) * 3);
                    un = true;
                }
            }
            cle = cle % 10;
            if (cle == 0)
            {
                return 0;
            }
            else
            {
                cle = 10 - cle;
            }
            return cle;
        }

    }
}