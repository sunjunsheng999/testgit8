using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insus.NET.Utilities
{
    public class CookieUtility
    {
        private static HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }

        private static HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }

        private static HttpCookie SystemCookie
        {
            get
            {
                return Request.Cookies["SystemCookie"] as HttpCookie;
            }
            set
            {
                if (Request.Cookies["SystemCookie"] != null)
                {
                    Request.Cookies.Remove("SystemCookie");
                }
                Response.Cookies.Add(value);
            }
        }

        private static HttpCookie NewSystemCookie
        {
            get
            {
                HttpCookie httpCookie = new HttpCookie("SystemCookie");
                return httpCookie;
            }
        }

        public static void RemoveSystemCookie()
        {
            if (SystemCookie == null)
                Response.Cookies.Remove("SystemCookie");
            else
                Response.Cookies["SystemCookie"].Expires = DateTime.Now.AddDays(-1);
        }

        public static bool IsLogin
        {
            get
            {
                return SystemCookie == null ? false : bool.Parse(SystemCookie.Values["IsLogin"]);
            }
            set
            {
                HttpCookie httpCookie = SystemCookie == null ? NewSystemCookie : SystemCookie;
                httpCookie.Values["IsLogin"] = value.ToString();
                SystemCookie = httpCookie;
            }
        }       

        public static string UserName
        {
            get
            {
                return SystemCookie == null ? string.Empty : SystemCookie.Values["UserName"];
            }
            set
            {
                HttpCookie httpCookie = SystemCookie == null ? NewSystemCookie : SystemCookie;
                httpCookie.Values["UserName"] = value;
                SystemCookie = httpCookie;
            }
        }      

        public static void Authorizationed()
        {
            if (!IsLogin)
            {
                Response.Redirect("~/Member/Index");
            }
        }
    }
}


