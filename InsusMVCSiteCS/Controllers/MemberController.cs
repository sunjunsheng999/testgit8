using Insus.NET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insus.NET;
using Insus.NET.Models;
using Insus.NET.Utilities;

namespace Insus.NET.Controllers
{
    public class MemberController : Controller
    {
        MemberEntity objMemberEntity = new MemberEntity();
        SecurityEntity objSecurityEntity = new SecurityEntity();
        //
        // GET: /Member/
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Member member)
        {
            objMemberEntity.Register(member);

            return Json(member, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()  //登录视图
        {
            if (CookieUtility.IsLogin)
                return RedirectToAction("Default", "Member");
            else
                return View();
        }

        public ActionResult Default() //登录成功之后进入的视图
        {
            CookieUtility.Authorizationed();

            return View();
        }

        [HttpPost]
        public ActionResult LoginVerify(Member member)
        {
            var Mem = objMemberEntity.LoginVerify(member);
            Mem.ForEach(delegate(Member mem)
            {
                CookieUtility.IsLogin = true;
                CookieUtility.UserName = mem.Account;
            });

            return Json(member, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SignOut()
        {
            CookieUtility.RemoveSystemCookie();
            var rtnData = new { RedirectUrl = Url.Action("Index", "Member") };

            return Json(rtnData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RequestPassword()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RequestPassword(Member member)
        {
            objMemberEntity.RequestPassword(member);
            
            return Json(member, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RequestChangePasswordMailContent(Security security)
        {
            return View(security);
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ResetPassword(Security security)
        {
            objSecurityEntity.ResetPassword(security);

            return Json(security, JsonRequestBehavior.AllowGet);
        }
    }
}


