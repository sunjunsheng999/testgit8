using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insus.NET.Results
{
    public class DownloadResult: ContentResult
    {
        private string fileName;
        private byte[] fileData;

        public DownloadResult(string fileName, byte[] fileData)
        {
            this.fileName = fileName;
            this.fileData = fileData;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if(string.IsNullOrEmpty(this.fileName))
                throw new Exception("指定文件名");

            if (this.fileData == null)
                throw new Exception("下载文件丢失或是被移除。");

            //var cd = string.Format("attachment; filename={0}", this.fileName);
            var cd = string.Format("attachment; filename={0}",
               HttpUtility.UrlEncode(this.fileName, System.Text.Encoding.UTF8));

            context.HttpContext.Response.AddHeader("Content-Disposition", cd);
            ContentType = "application/octet-stream";
            context.HttpContext.Response.BinaryWrite(this.fileData);
        }
    }
}

