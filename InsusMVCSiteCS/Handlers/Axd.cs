using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insus.NET.Handlers
{
    public class Axd : IHttpHandler
    {

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string parm = context.Request["v"];
            context.Response.ContentType = "text/Plain";
            context.Response.Write("Hello, " + parm + 
                                   ".<br />The current time is：" + DateTime.Now.ToString());
        }
    }
}