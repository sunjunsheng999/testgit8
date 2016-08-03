using Insus.NET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Insus.NET.Interfaces;
using System.Reflection;
using Insus.NET.Utilities;
using System.Data;

namespace Insus.NET.Handlers
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    public class AutoComplete : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string tableName = context.Request["tableName"];
            string prefix = context.Request["prefix"];
            context.Response.ContentType = "application/json";         
            Assembly assembly = Assembly.Load("InsusMVCSiteCS");
            Type objType = assembly.GetType("Insus.NET.Entities." + tableName + "Entity");
            IAutoCompletable iac = (IAutoCompletable)Activator.CreateInstance(objType);    
            DataTable dt = iac.GetWord(prefix);

            string data = DataEntity.DataTableToJSON(dt);
            context.Response.Write(data);
        }        

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}