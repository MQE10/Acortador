using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public static class QR
    {
        public static byte[] GenerarQR(string pTexto)
        {

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(pTexto, QRCodeGenerator.ECCLevel.Q);

            PngByteQRCode qrCodePNG = new PngByteQRCode(qrCodeData);
            byte[] qrCodeImageBmp = qrCodePNG.GetGraphic(20);

            //QRCodeWriter qr = new QRCodeWriter();

            //var matrix = qr.encode(pTexto, ZXing.BarcodeFormat.QR_CODE, 400, 400);

            //ZXing.BarcodeWriter w = new ZXing.BarcodeWriter();

            //w.Format = ZXing.BarcodeFormat.QR_CODE;

            //Bitmap img = w.Write(matrix);





            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //byte[] iByteArrayImagenReal;
            //iByteArrayImagenReal = ms.GetBuffer();


            return qrCodeImageBmp;


        }

    }
}
