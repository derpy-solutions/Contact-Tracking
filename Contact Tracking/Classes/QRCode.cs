using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System.Drawing.Imaging;

namespace Contact_Tracking
{
    public class MyQRCode
    {
        public static ImageCodecInfo GetEncoderInfo(String mimeType)
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

        public static Bitmap Create(Person person)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 300, Height = 300, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap;
            if (person != null)
            {
                bitmap = barcodeWriter.Write(Encryption.Encrypt(person.QRData));
            }
            else
            {
                bitmap = barcodeWriter.Write(Encryption.Encrypt(""));
            }
            Bitmap logo = new Bitmap(Properties.Resources.derpy_50x50);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));

            return bitmap;
        }

        public static void Save(Person person)
        {
            if (!Directory.Exists(Properties.Settings.Default.DataPath + @"\QR Codes\"))
            {
                Directory.CreateDirectory(Properties.Settings.Default.DataPath + @"\QR Codes\");
            }

            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            myEncoderParameters = new EncoderParameters(1);

            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;

            Bitmap bitmap = Create(person);
            bitmap.Save(Properties.Settings.Default.DataPath + @"\QR Codes\" + person.FileName + ".jpg", myImageCodecInfo, myEncoderParameters);
        }
    }
}
