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
            int reader = Convert.ToInt32(enter);

            Random rd = new Random();
            Console.WriteLine(Math.Pow(10, (12 - Math.Floor(Math.Log10(reader) + 1))));
            Console.ReadLine();

            double randomRange2 = Math.Pow(10, (12 - Math.Floor(Math.Log10(reader) + 1)));

            double code = Math.Abs(rd.NextDouble() * (randomRange2 - 0) + 0);

            Console.WriteLine(String.Format("{0:0}", code));
            Console.ReadLine();

            Barcode b = new Barcode();
            Image img = b.Encode(BarcodeLib.TYPE.EAN13, String.Format("{0:0}", code) + reader.ToString(), Color.Black, Color.White, 290, 120);
            img.Save("toto2.png");
        }
    }
}
