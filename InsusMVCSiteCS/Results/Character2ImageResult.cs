using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insus.NET.Results
{
    public class Character2ImageResult : ContentResult
    {
         public string _text;
         public Character2ImageResult(string text)
        {
            _text = text;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Font font = new Font("Arial", 25, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(_text, font).Width;
            int height = (int)graphics.MeasureString(_text, font).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(_text, font, new SolidBrush(Color.FromArgb(0, 0, 0)), 0, 0);
            graphics.Flush();
            graphics.Dispose();

            HttpContextBase hcb = context.HttpContext;
            hcb.Response.Clear();
            hcb.Response.ContentType = "image/gif";
            bitmap.Save(hcb.Response.OutputStream, ImageFormat.Gif);
            bitmap.Dispose();
        }   
    }
}
