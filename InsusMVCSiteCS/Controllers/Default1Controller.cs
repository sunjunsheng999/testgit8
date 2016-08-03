using Insus.NET.AspNets;
using Insus.NET.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.UI;
using Insus.NET.Entities;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Insus.NET.Controllers
{
    public class Default1Controller : Controller
    {
        //
        // GET: /Default1/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RdlcReportDemo()
        {
            string aspx = "/AspNets/RdlcView.aspx";
            using (var sw = new StringWriter())
            {
                System.Web.HttpContext.Current.Server.Execute(aspx, sw, true);
                return Content(sw.ToString());
            }
        }

        public ActionResult AxdDemo()
        {
            return View();
        }

        public ActionResult RdlcSearchReport()
        {
            string aspx = "/AspNets/FruitSearchView.aspx";
            using (var sw = new StringWriter())
            {
                System.Web.HttpContext.Current.Server.Execute(aspx, sw, true);
                return Content(sw.ToString());
            }
        }

        public ActionResult ConvertBmpToJpg()
        {
            return View();
        }

        public JsonResult ConverToJpg(string bmp)
        {
            string _bmp = Server.MapPath(bmp);
            string newfile = "/Temp/a.jpg";

            BitmapUtility.Bitmap2OtherImageFormat(_bmp, Server.MapPath(newfile), System.Drawing.Imaging.ImageFormat.Jpeg);

            return Json(new { result = newfile });
        }
    }
}