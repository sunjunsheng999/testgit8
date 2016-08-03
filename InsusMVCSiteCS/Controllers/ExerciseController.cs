using Insus.NET.ServiceReference1;
using Insus.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Insus.NET.Models;
using Insus.NET.Results;
using System.IO;
using Insus.NET.Utilities;
using System.Data;
using Insus.NET.Entities;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Insus.NET.Controllers
{
    public class ExerciseController : Controller
    {
        public ActionResult WebServiceDemo()
        {
            return View();
        }

        public ActionResult WcfServiceDemo()
        {
            return View();
        }

        public ContentResult GetCalcResult(string Operate, decimal number1, decimal number2)
        {
            decimal rtn = 0m;
            CalculatorClient calc = new CalculatorClient();
            switch (Operate)
            {
                case "Add":
                    rtn = calc.Add(number1, number2);
                    break;
                case "Subtract":
                    rtn = calc.Subtract(number1, number2);
                    break;
                case "Multiply":
                    rtn = calc.Multiply(number1, number2);
                    break;
                case "Divide":
                    rtn = calc.Divide(number1, number2);
                    break;
            }

            return Content(rtn.ToString());
        }

        public ActionResult MediaMemo()
        {
            return View();
        }

        public ContentResult MediaVideoPlayer()
        {
            //这里处理传入视频参数，可以从前台也可以从数据库。            
            int _Width = 400;
            int _Height = 300;
            string _File = "/UploadFiles/Wildlife.wmv";

            string mediaComponents = @"<OBJECT id='mediaPlayer1' width=" + _Width + " height=" + _Height +
                     " classid='CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95'"
                    + @"codebase='http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701'"
                    + @"standby='Loading Microsoft Windows Media Player components...' type='application/x-oleobject'>"
                    + @"<param name='fileName' value=" + _File + ">"
                    + @"<param name='animationatStart' value='true'>"
                    + @"<param name='transparentatStart' value='true'>"
                    + @"<param name='autoStart' value='false'>"
                    + @"<param name='showControls' value='true'>"
                    + @"<param name ='ShowAudioControls' value='true'>"
                    + @"<param name='ShowStatusBar' value='true'>"
                    + @"<param name='loop' value='false'>"
                    + @"<EMBED type='application/x-mplayer2'"
                    + @"pluginspage='http://microsoft.com/windows/mediaplayer/en/download/'"
                    + @"id='mediaPlayer' name='mediaPlayer' displaysize='4' autosize='-1'"
                    + @"bgcolor='darkblue' showcontrols='true' showtracker='-1'"
                    + @"showdisplay='0' showstatusbar='-1' videoborder3d='-1' width=" + _Width + " height=" + _Height + ""
                    + @"src=" + _File + " autostart='false' designtimesp='5311' loop='false'></EMBED>"
                    + @"</OBJECT>";

            return Content(mediaComponents);
        }

        public ActionResult SwfVideoDemo()
        {
            return View();
        }

        public ContentResult SwfPlayer()
        {
            int _Width = 400;
            int _Height = 300;
            string _File = "/UploadFiles/Wildlife.swf";

            string objFlash = @"<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' 
                                codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' 
                                width=" + _Width + " height=" + _Height + ">"
            + @"<param name='movie' value=" + _File + ">"
            + @"<param name='quality' value='high'>"
            + @"<embed src=" + _File +
                               " quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width="
                               + _Width + " height=" + _Height + "></embed>"
            + @"</object>";
            return Content(objFlash);
        }

        public ActionResult RmDemo()
        {
            return View();
        }

        public ContentResult GetRm()
        {
            int _Width = 400;
            int _Height = 300;
            int _cph = 30;
            bool _isAutostart = false;
            string _File = "/UploadFiles/[余世维-赢在执行].赢在执行01.rm";

            string rmId = "RealPlayer" + Guid.NewGuid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendFormat("<OBJECT id=\"" + rmId + "\" classid=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\" width=\"{0}\" height=\"{1}\">", _Width, _Height);
            sb.AppendFormat("<param name=\"src\" value=\"{0}\">", _File);
            sb.AppendFormat("<param name=\"autostart\" value=\"{0}\">", _isAutostart);
            sb.Append("<param name=\"controls\" value=\"imagewindow\">");
            sb.Append("<param name=\"console\" value=\"video\">");
            sb.Append("<param name=\"loop\" value=\"false\">");
            sb.AppendFormat("<EMBED src=\"{0}\" width=\"{1}\" height=\"{2}\" controls=\"ControlPanel\" type=\"audio/x-pn-realaudio-plugin\" console=\"video\" autostart=\"true\">", _File, _Width, _cph);
            sb.Append("</EMBED>");
            sb.Append("</OBJECT>");
            sb.Append("<br />");
            sb.AppendFormat("<OBJECT id=\"" + rmId + "\" classid=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\" width=\"{0}\" height=\"{1}\">", _Width, _cph);
            sb.AppendFormat("<param name=\"src\" value=\"{0}\">", _File);
            sb.AppendFormat("<param name=\"autostart\" value=\"{0}\">", _isAutostart);
            sb.Append("<param name=\"controls\" value=\"ControlPanel\">");
            sb.Append("<param name=\"console\" value=\"video\">");
            sb.AppendFormat("<EMBED src=\"{0}\" width=\"{1}\" height=\"{2}\" controls=\"ControlPanel\" type=\"audio/x-pn-realaudio-plugin\" console=\"video\" autostart=\"true\">", _File, _Width, _cph);
            sb.Append("</EMBED>");
            sb.Append("</OBJECT>");

            return Content(sb.ToString());
        }

        public ActionResult RmvbDemo()
        {
            return View();
        }

        public RmvbResult PlayRmvb()
        {
            VideoMedia objvm = new VideoMedia();
            objvm.FilePath = "/UploadFiles/a.rmvb";
            objvm.Width = 400;
            objvm.Height = 300;

            return new RmvbResult(objvm);
        }

        public ActionResult FlvDemo()
        {
            return View();
        }

        public PartialViewResult PlayFlv(VideoMedia vm)
        {
            return PartialView("_Flv", vm);
        }

        public ActionResult AviDemo()
        {
            VideoMedia vm = new VideoMedia();
            vm.Width = 400;
            vm.Height = 300;
            vm.FilePath = "/UploadFiles/Wildlife.avi";

            return View(vm);
        }

        public ActionResult FileDownloadDemo()
        {
            return View();
        }

        public DownloadResult Download(int id)
        {
            FileLibrary fl = new FileLibrary();
            fl.FileLibrary_nbr = id;

            FileLibraryEntity fle = new FileLibraryEntity();
            DataTable dt;

            try
            {
                dt = fle.GetUploadFileByPrimaryKey(fl);
            }
            catch (Exception ex)
            {
                throw new Exception("下载记录不存在。 " + ex.Message);
            }


            DataRow dr = dt.Rows[0];
            string fileName = dr["OldFileName"].ToString();
            string fileNewName = dr["NewFileName"].ToString();

            string filePath = "~/UploadFiles";
            var fullFilePath = string.Format("{0}/{1}", filePath, fileNewName);

            try
            {
                var fileData = FileUtility.GetFileData(Server.MapPath(fullFilePath));
                return new DownloadResult(fileName, fileData);
            }
            catch (FileNotFoundException)
            {
                throw new HttpException(404, "下载文件丢失或是被移除。");
            }
        }

        public ActionResult FileListMgr()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Delete(FileLibrary fl)
        {
            FileLibraryEntity fle = new FileLibraryEntity();
            DataTable dt = fle.GetUploadFileByPrimaryKey(fl);

            if (dt.Rows.Count <= 0)
                throw new Exception("记录不存在。");

            DataRow dr = dt.Rows[0];
            string fileNewName = dr["NewFileName"].ToString();

            string filePath = "~/UploadFiles";
            var fullFilePath = string.Format("{0}/{1}", filePath, fileNewName);

            if (System.IO.File.Exists(Server.MapPath(fullFilePath)))
                System.IO.File.Delete(Server.MapPath(fullFilePath));

            fle.Delete(fl);

            return Json(fle, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ContentResult Update(HttpPostedFileBase Filedata, FileLibrary fl)
        {
            string fileSavedFolder = Server.MapPath("~/UploadFiles/");

            FileLibraryEntity fle = new FileLibraryEntity();
            DataTable dt = fle.GetUploadFileByPrimaryKey(fl);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string fileNewName = dr["NewFileName"].ToString();
                var fullFilePath = Path.Combine(fileSavedFolder, fileNewName);

                if (System.IO.File.Exists(fullFilePath))
                    System.IO.File.Delete(fullFilePath);
            }

            if (Filedata != null && Filedata.ContentLength > 0)
            {
                string oldName = Filedata.FileName;
                string extName = Path.GetExtension(oldName);
                string newName = Guid.NewGuid().ToString() + extName;
                int size = Filedata.ContentLength;

                Filedata.SaveAs(Path.Combine(fileSavedFolder, newName));

                FileLibrary ofl = new FileLibrary();
                ofl.FileLibrary_nbr = fl.FileLibrary_nbr;
                ofl.OldFileName = oldName;
                ofl.NewFileName = newName;
                ofl.Extension = extName;
                ofl.Size = size;

                FileLibraryEntity ofle = new FileLibraryEntity();
                ofle.Update(ofl);
            }
            return Content("");
        }

        public ActionResult CharacterDemo()
        {
            return View();
        }

        public ContentResult GetRandomString()
        {
            string rndStr = CharacterUtility.GenerateRandomString().ToString();
            return Content(rndStr);
        }

        public ActionResult DisplayBase64Image()
        {
            return View();
        }

        public JsonResult GetBase64Image()
        {
            FileStream fileStream = new FileStream(Server.MapPath("~/UploadFiles/swfobject_logo.gif"), FileMode.Open, FileAccess.Read);
            byte[] data = new byte[(int)fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            object d = new { Base64Imgage = Convert.ToBase64String(data) };

            return Json(d, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CaptchaDemo()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Verify(string code)
        {
            string message = "验证码错误，请重新输入正确的验证码。";
            string sessionCaptcha = HttpContext.Session["CAPTCHA_Contact"] == null ? "" : HttpContext.Session["CAPTCHA_Contact"].ToString();

            if (sessionCaptcha == code)
            {
                message = "验证码正确。";
            }

            object d = new { Message = message };

            return Json(d, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CaptchaDemo_Ver2()
        {
            return View();
        }

        public CaptchaResult GetCapptImage()
        {
            string randomText = CharacterUtility.GenerateRandomString();
            HttpContext.Session.Add("CAPTCHA", randomText);
            return new CaptchaResult(randomText);
        }

        [HttpPost]
        public JsonResult CaptchaValid(string captchaText)
        {
            string message = "验证码错误，请重新输入正确的验证码。";

            string sessionCaptcha = HttpContext.Session["CAPTCHA"] == null ?
                "" : HttpContext.Session["CAPTCHA"].ToString();

            if (sessionCaptcha == captchaText)
            {
                message = "验证码正确。";
            }

            object d = new { Message = message };

            return Json(d, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Character2Image()
        {
            return View();
        }

        public Character2ImageResult Char2Img()
        {
            string randomText = CharacterUtility.GenerateRandomString();
            return new Character2ImageResult(randomText);
        }

        public ActionResult WatermarkDemo()
        {
            return View();
        }

        [HttpPost]
        public ContentResult ProessWatermark()
        {
            string text = CharacterUtility.GenerateRandomString();

            Bitmap sBitmap = new Bitmap(Server.MapPath("~/UploadFiles/aa.png"));

            Bitmap bitmap = BitmapUtility.PaintWatermark(text, sBitmap);

            string watermarkImageFileName = Guid.NewGuid() + ".gif";
            bitmap.Save(Server.MapPath("~/Temp/" + watermarkImageFileName), ImageFormat.Png);
            bitmap.Dispose();
            string imgHtml = "<img id=\"img1\" src=\"/Temp/" + watermarkImageFileName + "\"></div>";
            return Content(imgHtml);
        }

        public ActionResult CropImageDemo()
        {
            return View();
        }

        [HttpPost]
        public ContentResult CropImage()
        {
            Bitmap sBitmap = new Bitmap(Server.MapPath("~/UploadFiles/PeachBlossom.png"));

            Rectangle section = new Rectangle(new Point(450, 250), new Size(315, 100));

            Bitmap CroppedImage = BitmapUtility.CutImage(sBitmap, section);

            string cropImageFileName = Guid.NewGuid() + ".png";
            CroppedImage.Save(Server.MapPath("~/Temp/" + cropImageFileName), ImageFormat.Png);
            CroppedImage.Dispose();

            string imgHtml = "<img id=\"img1\" src=\"/Temp/" + cropImageFileName + "\"></div>";
            return Content(imgHtml);
        }

        public ActionResult CaptchaDemo_Ver3()
        {
            return View();
        }

        public ContentResult GetCaptchaImage()
        {
            //验证码字符
            string randomText = CharacterUtility.GenerateRandomString();

            //剪切图片
            Bitmap sBitmap = new Bitmap(Server.MapPath("~/UploadFiles/PeachBlossom.png"));

            //验证码宽与高：
            int w = 315;
            int h = 100;

            //图片可剪切区域，分别需要减去验证码的长度与高度
            int i = sBitmap.Width - w;
            int j = sBitmap.Height - h;

            //随机获取开始剪切点
            Random _random = new Random();
            int x = _random.Next(0, i);
            int y = _random.Next(0, j);

            //剪切区域
            Rectangle section = new Rectangle(new Point(x, y), new Size(w, h));

            //剪切好的图片
            Bitmap CroppedImage = BitmapUtility.CutImage(sBitmap, section);
            
            //开始把随机字符串写入刚剪切好的图片上
            Bitmap captchaBitmap = BitmapUtility.PaintWatermark(randomText,CroppedImage );

            //下面的不说了，你明白的
            string captchaImage = Guid.NewGuid() + ".gif";
            captchaBitmap.Save(Server.MapPath("~/Temp/" + captchaImage), ImageFormat.Png);
            captchaBitmap.Dispose();
            string imgHtml = "<img id=\"img1\" src=\"/Temp/" + captchaImage + "\"></div>";
            return Content(imgHtml);
            
        }
    }
}