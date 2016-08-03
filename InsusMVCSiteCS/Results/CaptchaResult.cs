using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Mvc;

namespace Insus.NET.Results
{
    public class CaptchaResult: ContentResult
    {
        public string _captchaText;
        public CaptchaResult(string captchaText)
        {
            _captchaText = captchaText;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            using (Bitmap b = new Bitmap(150, 40, PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(b))
                {
                    Rectangle rect = new Rectangle(0, 0, 149, 39);
                    g.FillRectangle(Brushes.White, rect);

                    Font drawFont = new Font("Arial", 16, FontStyle.Italic | FontStyle.Strikeout);
                    using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                    {
                        PointF drawPoint = new PointF(15, 10);

                        g.DrawRectangle(new Pen(Color.Red, 0), rect);
                        g.DrawString(_captchaText, drawFont, drawBrush, drawPoint);
                    }
                    HttpContextBase hcb = context.HttpContext;
                    hcb.Response.Clear();
                    hcb.Response.ContentType = "image/jpeg";
                    b.Save(hcb.Response.OutputStream, ImageFormat.Jpeg);
                    b.Dispose();
                }
            }
        }       
    }
}