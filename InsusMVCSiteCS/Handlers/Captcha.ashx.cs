using Insus.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Insus.NET.Handlers
{
    /// <summary>
    /// Summary description for Captcha1
    /// </summary>
    public class Captcha1 : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            
            using (Bitmap b = new Bitmap(150, 40, PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    Rectangle rect = new Rectangle(0, 0, 149, 39);
                    g.FillRectangle(Brushes.White, rect);

                    String drawCaptchaString = CharacterUtility.GenerateRandomString();
                    HttpContext.Current.Session["CAPTCHA_Contact"] = drawCaptchaString;
                  
                    Font drawFont = new Font("Arial", 16, FontStyle.Italic | FontStyle.Strikeout);
                    using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                    {                        
                        PointF drawPoint = new PointF(15, 10);
                                                
                        g.DrawRectangle(new Pen(Color.Red, 0), rect);
                        g.DrawString(drawCaptchaString, drawFont, drawBrush, drawPoint);
                    }

                    b.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    context.Response.ContentType = "image/jpeg";
                    context.Response.End();
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}