using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Insus.NET.Services
{   
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SayHello : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Hi(string userName)
        {
            string un = string.IsNullOrEmpty(userName) ? "Insus.NET" : userName;            
            if (DateTime.Now.Hour > 6 && DateTime.Now.Hour < 12)
                return "Hi " + un + ", good morning.";
            if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 18)
                return "Hi " + un + ", good afternoon.";
            if (DateTime.Now.Hour > 18 && DateTime.Now.Hour < 6)
                return "Hi " + un + ", good evening.";
            return "Hi " + un;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Say(string userName)
        {            
           string un = string.IsNullOrEmpty(userName) ? "Insus.NET" : userName;
           return "Hello " + un;
        }
    }
}
