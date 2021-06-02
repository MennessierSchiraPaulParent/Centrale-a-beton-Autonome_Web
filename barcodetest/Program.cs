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

            Random rd = new Random();

            double randomRange2 = Math.Pow(10, (12 - Math.Floor(Math.Log10(reader) + 1)));
            double code = Math.Abs(rd.NextDouble() * (randomRange2 - 0) + 0);
            
            Console.WriteLine(Math.Round(code, 0).ToString() + reader.ToString());
            Console.ReadLine();

            Console.WriteLine(controlkey(reader, code));
            

            Barcode b = new Barcode();
            Image img = b.Encode(BarcodeLib.TYPE.EAN13, Math.Round(code,0).ToString() + reader.ToString(), Color.Black, Color.White, 290, 120);
            img.Save("toto1.png");

        }
        public static int controlkey(int reader, double code)
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
                }else if(!un){
                    cle += ((int)Char.GetNumericValue(a) * 3);
                    un = true;
                }
            }
            Console.WriteLine(cle);
            Console.Read();
            cle = cle % 10;
            if(cle == 0)
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
