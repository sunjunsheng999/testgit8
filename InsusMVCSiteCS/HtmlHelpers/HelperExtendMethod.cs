using Insus.NET.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Insus.NET.HtmlHelpers
{
    public static class HelperExtendMethod
    {
        public static string Hi(this HtmlHelper helper, string userName)
        {
            if (DateTime.Now.Hour < 12)
                return "Hi " + userName + " good morning!";
            else
                return "Hi " + userName + " good evening!";
        }

        public static string Say(this HtmlHelper helper, string userName)
        {
            if (DateTime.Now.Hour < 12)
                return "Hello " + userName;
            else
                return "Hello " + userName;
        }

        public static HtmlString RenderControl<T>(this HtmlHelper helper, string path) 
            where T : UserControl
        {
            return AscxUtility.RenderControl<T>(path);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string name)
        {
            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("src", name + ".png");
            return new MvcHtmlString(img.ToString());
        }

        public static MvcHtmlString NewImage(this HtmlHelper helper, DateTime dt)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", "/content/Images/new.gif");
            builder.MergeAttribute("alt", "");
            var hv = DateTime.Now.AddDays(-2) >= dt ? "none" : "visible";
            builder.MergeAttribute("style", "display:" + hv);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}

