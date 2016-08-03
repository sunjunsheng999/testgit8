using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Insus.NET.Utilities
{
    public class BitmapUtility
    {
        public static Bitmap PaintWatermark(string text, Bitmap sourceImage)
        {
            Bitmap bitmap = new Bitmap(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(sourceImage, 0, 0);
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    float emSize = 30;
                    float x = bitmap.Width / 2;
                    float y = bitmap.Height / 2 - emSize;
                    Font font = new Font("Arial", emSize, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
                    PointF pointF = new PointF(x, y);
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;

                    g.DrawString(text, font, brush, pointF, sf);
                }

                g.Dispose();
            }
            return bitmap;
        }

        public static Bitmap CutImage(Bitmap sourceImage, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(sourceImage, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        public static void Bitmap2OtherImageFormat(string bmpFullPath, string newImageFullPath, ImageFormat imageFormat)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(bmpFullPath);
            img.Save(newImageFullPath, imageFormat);
        }
    }
}