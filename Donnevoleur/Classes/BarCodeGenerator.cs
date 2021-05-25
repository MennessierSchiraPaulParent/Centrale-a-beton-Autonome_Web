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
        ImageCodecInfo myImageCodecInfo;
        Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;
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
            
            //Nouvelle façon d'encode
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            myEncoder = Encoder.Quality;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(myEncoder, 25L);
            myEncoderParameters.Param[0] = myEncoderParameter;


            img.Save("commandNumber.jpg", myImageCodecInfo,myEncoderParameters);

            
            //return b.Encode(BarcodeLib.TYPE.EAN13, String.Format("{0:0}", code) + idCommande.ToString(), Color.Black, Color.White, 290, 120);
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}