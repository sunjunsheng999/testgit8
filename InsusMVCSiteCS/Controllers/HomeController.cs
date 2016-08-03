using Insus.NET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insus.NET.Models;
using System.IO;
using Insus.NET.Utilities;
using System.Web.Script.Serialization;

namespace Insus.NET.Controllers
{
    public class HomeController : Controller
    {
        FruitKindEntity objFruitKindEntity = new FruitKindEntity();

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageA()
        {
            return View();
        }

        public ActionResult JQueryAutoCompleteDemo()
        {
            return View();
        }

        public ActionResult JQueryAutoCompleteDemo1()
        {
            return View();
        }

        public ActionResult DynamicLoad()
        {
            return View();
        }

        public PartialViewResult PV(PvParam pvp)
        {
            return PartialView("_Partial1", pvp);
        }

        public JsonResult GetDateFormatForRadio()
        {
            MiscellaneousEntity misc = new MiscellaneousEntity();

            var model = misc.RadioItemLists();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListDemo()
        {
            return View();
        }

        public JsonResult GetDestinyLists()
        {
            MiscellaneousEntity misc = new MiscellaneousEntity();
            var model = misc.DestinyLists();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckboxListDemo()
        {
            return View();
        }

        public JsonResult GetEightDiagramLists()
        {
            MiscellaneousEntity misc = new MiscellaneousEntity();
            var model = misc.EightDiagramLists();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FlexPaperView()
        {
            return View();
        }

        public JsonResult GetSwf(FlexPaper fp)
        {
            FlexPaperEntity fpe = new FlexPaperEntity();
            var model = fpe.GetSwfFile(fp);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UploadFileDemo()
        {
            return View();
        }

        [HttpPost]
        public ContentResult UploadFile(HttpPostedFileBase Filedata)
        {
            if (Filedata != null && Filedata.ContentLength > 0)
            {
                string fileSavedFolder = Server.MapPath("~/UploadFiles/");
                string oldName = Filedata.FileName;
                string extName = Path.GetExtension(oldName);
                string newName = Guid.NewGuid().ToString() + extName;                

                string fileType = Filedata.ContentType;
                int size = Filedata.ContentLength;
                Filedata.SaveAs(Path.Combine(fileSavedFolder, newName));

                FileLibrary fl = new FileLibrary ();
                fl.OldFileName = oldName;
                fl.NewFileName = newName;
                fl.Extension = extName;
                fl.Size = size;

                FileLibraryEntity fle = new FileLibraryEntity();
                fle.Insert(fl);       
            }
            return Content("");
        }
        
        public ActionResult ViewUploadPhoto()
        {
            return View();
        }

        public JsonResult GetAllUploadFile()
        {
            FileLibraryEntity fle = new FileLibraryEntity();
            var model = fle.GetAllUploadFiles();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUploadFilebyByPrimaryKey(FileLibrary fl)
        {
            FileLibraryEntity fle = new FileLibraryEntity();
            var model = fle.GetAllUploadFilesByPrimaryKey(fl);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ContentResult GetThumbnailImage(FileLibrary fl)
        {
            string oImgUrl = "~/UploadFiles/" + fl.NewFileName;
           
            string extName = Path.GetExtension(fl.NewFileName);
            string newName = Guid.NewGuid().ToString() + extName;
            string nImgUrl = "~/Temp/" + newName;

            Thumbnail.GenerateThumbnail(Server.MapPath(oImgUrl), Server.MapPath(nImgUrl), 96, 96);

            string htmltag = "<img id=\"img1\"  src=\"/Temp/" + newName + "\"/>";
            return Content(htmltag);            
        }
        
        public ContentResult GetImage(FileLibrary fl)
        {           
            string htmltag = "<img id=\"img1\"  src=\"/UploadFiles/" + fl.NewFileName + "\"/>";
            return Content(htmltag);
        }

        public ActionResult FlashDemo()
        {
            return View();
        }

        public JsonResult GetFlashObject()
        {
            List<FlashObject> oo = new List<FlashObject>();
            FlashObject fo = new FlashObject();
            fo.FilePath = "/UploadFiles/test.swf"; ;
            fo.ContainerId = "flashContent";
            fo.Width = 300;
            fo.Height = 120;
            oo.Add(fo);

            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //string output = jss.Serialize(oo);
            return Json(oo, JsonRequestBehavior.AllowGet);
        }


    }
}


