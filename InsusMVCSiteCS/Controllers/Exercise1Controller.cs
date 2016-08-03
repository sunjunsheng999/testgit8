using Insus.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insus.NET.Interfaces;
using System.Reflection;
using System.Dynamic;
using Insus.NET.Utilities;
using System.IO;

namespace Insus.NET.Controllers
{
    public class Exercise1Controller : Controller
    {
        public ActionResult Preview(string str)
        {
            string pv = (string)ViewData["pv"];
            return View(pv);
        }

        public ActionResult Page1()
        {
            return View();
        }

        public JsonResult Page1Preview(Model1 m1)
        {
            var pv = RenderUtility.PartialView(this, "_PartialPage1", m1);
            ViewData["pv"] = pv;
            return Json(new { url = Url.Action("Preview", "Exercise1") });

        }

        public ActionResult Page2()
        {
            return View();
        }

        public JsonResult Page2Preview(Model2 m2)
        {
            var pv = RenderUtility.PartialView(this, "_PartialPage2", m2);
            return Json(new { url = Url.Action("Preview", "Exercise1", pv) });
        }

        public ActionResult VerifyImage()
        {
            return View();
        }

        public JsonResult Verify()
        {
            string val = "Is an Image";
            string filePath = "~/UploadFiles/img.txt.jpg"; //PeachBlossom.png

            // string imgStr = ImageUtility.Base64String(filePath);
            //if (!ImageUtility.IsImage(imgStr))


            if (!ImageUtility.IsImage1(filePath))
                val = "Not an image";

            return Json(new { result = val });
        }

        [HttpPost]
        public ContentResult UploadImageFile(HttpPostedFileBase Filedata)
        {
            string errorString = string.Empty;

            if (!ImageUtility.IsImage(Filedata))
            {
                errorString = "InValid an image";
            }
            else
                if (Filedata != null && Filedata.ContentLength > 0)
                {
                    string fileSavedFolder = Server.MapPath("~/UploadFiles/");
                    string oldName = Filedata.FileName;
                    string extName = Path.GetExtension(oldName);
                    string newName = Guid.NewGuid().ToString() + extName;

                    string fileType = Filedata.ContentType;
                    int size = Filedata.ContentLength;
                    Filedata.SaveAs(Path.Combine(fileSavedFolder, newName));
                }

            return Content(errorString);
        }

        public ActionResult InputFilePath()
        {
            return View();
        }       
    }
}