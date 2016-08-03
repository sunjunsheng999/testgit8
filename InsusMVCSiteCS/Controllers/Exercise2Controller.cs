using Insus.NET.AspNets;
using Insus.NET.Entities;
using Insus.NET.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Insus.NET.Controllers
{
    public class Exercise2Controller : Controller
    {
        public ActionResult AspxTest()
        {
            string aspx = "/AspNets/WebForm1.aspx";
            using (var sw = new StringWriter())
            {
                System.Web.HttpContext.Current.Server.Execute(aspx, sw, true);
                return Content(sw.ToString());
            }
        }

        public ActionResult UcTest()
        {
            //var page = new Page();
            //var uc = page.LoadControl("~/AspNets/WebUserControl1.ascx");
            //page.Controls.Add(uc);
            //using (var sw = new StringWriter())
            //{
            //    System.Web.HttpContext.Current.Server.Execute(page, sw, true);
            //    return Content(sw.ToString());
            //}

            HtmlString hs = AscxUtility.RenderControl<WebUserControl1>("~/AspNets/WebUserControl1.ascx");
            return Content(hs.ToString());
        }

        public ActionResult ViewAscx()
        {
            return View();
        }

        public ActionResult AscxSetValTest()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Name", "Insus.NET");
            HtmlString hs = AscxUtility.RenderControl<SetValForUc>("~/AspNets/SetValForUc.ascx", dic);
            return Content(hs.ToString());
        }

        public ActionResult AscxDemo()
        {
            return View();
        }

        public ContentResult ShowUc()
        {
            HtmlString hs = AscxUtility.RenderControl<Uc1>("~/AspNets/Uc1.ascx");
            return Content(hs.ToString());
        }

        public ActionResult JQueryLoadPartialView()
        {
            return View();
        }

        public PartialViewResult News()
        {
            return PartialView("_News");
        }

        public PartialViewResult Article()
        {
            return PartialView("_Article");
        }

        public ActionResult NewsList()
        {
            NewsEntity ne = new NewsEntity();
            var model = ne.GetAll();
            return View(model);
        }
    }
}

