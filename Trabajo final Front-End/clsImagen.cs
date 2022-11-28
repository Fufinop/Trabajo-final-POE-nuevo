using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace Trabajo_final_Front_End
{
    class clsImagen
    {
        //Convierte byte a imagen
        public static MemoryStream ByteToImage(byte[] array)
        {
            MemoryStream ms = new MemoryStream();
            return ms;
        }

        //Convierte imagen a byte 
        public static byte [] ImageToByte(Image imagenIn)
        {
            MemoryStream ms = new MemoryStream();
            imagenIn.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }
    
    }
}
