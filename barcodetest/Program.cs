using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BarcodeLib;
namespace barcodetest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Entrez l'id de commande :");
            string enter = Console.ReadLine();
            int reader = Int32.Parse(enter);
            Console.WriteLine(reader);

            Random rd = new Random();
            Console.WriteLine(Math.Pow(10, (12 - Math.Floor(Math.Log10(reader) + 1))));
            Console.ReadLine();

            double randomRange2 = Math.Pow(10, (12 - Math.Floor(Math.Log10(reader) + 1)));

            double code = Math.Abs(rd.NextDouble() * (randomRange2 - 0) + 0);
            
            Console.WriteLine(String.Format("{0:0}", code));
            Console.ReadLine();

            Console.WriteLine(controlkey(reader, code));
            

            Barcode b = new Barcode();
            Image img = b.Encode(BarcodeLib.TYPE.EAN13, String.Format("{0:0}", code + reader) + reader.ToString(), Color.Black, Color.White, 290, 120);
            img.Save("toto1.png");

           
        }
        public static int controlkey(int reader, double code)
        {
            int cle = 0;
            bool trois = false;
            code = Math.Round(code, 0);

            string chaineATraiter = code.ToString() + reader.ToString();

            foreach (char a in chaineATraiter)
            {
                if (trois)
                {
                    cle += (Convert.ToInt32(a) * 3);
                    trois = false;
                }
                else
                {
                    cle += (Convert.ToInt32(a) * 1);
                    trois = true;
                }
            }
            cle = cle % 10;
            cle = 10 - cle;

            return cle;
        }

    }
}
