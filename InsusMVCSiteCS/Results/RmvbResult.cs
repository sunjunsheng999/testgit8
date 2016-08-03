using Insus.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insus.NET.Results
{
    public class RmvbResult : ContentResult
    {
        private string filePath;
        private int width;
        private int height;

        public RmvbResult(VideoMedia vm)
        {
            this.filePath = vm.FilePath;
            this.width = vm.Width;
            this.height = vm.Height;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            string id = "RealPlayer" + Guid.NewGuid();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.AppendFormat("<object id=\"{0}\" width=\"{1}\" height=\"{2}\" classid=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\">", id, width, height);
            sb.Append("<param name=\"_ExtentX\" value=\"12700\">");
            sb.Append("<param name=\"_ExtentY\" value=\"9525\">");
            sb.Append("<param name=\"AUTOSTART\" value=\"0\">");
            sb.Append("<param name=\"SHUFFLE\" value=\"0\">");
            sb.Append("<param name=\"PREFETCH\" value=\"0\">");
            sb.Append("<param name=\"NOLABELS\" value=\"0\">");
            sb.AppendFormat("<param name=\"SRC\" value=\"{0}\">", filePath);
            sb.Append("<param name=\"CONTROLS\" value=\"ImageWindow\">");
            sb.Append("<param name=\"CONSOLE\" value=\"Clip\">");
            sb.Append("<param name=\"LOOP\" value=\"0\">");
            sb.Append("<param name=\"NUMLOOP\" value=\"0\">");
            sb.Append("<param name=\"CENTER\" value=\"0\">");
            sb.Append("<param name=\"MAINTAINASPECT\" value=\"0\">");
            sb.Append("<param name=\"BACKGROUNDCOLOR\" value=\"#000000\">");
            sb.Append("</object>");
            sb.Append("<br>");
            sb.AppendFormat("<object  id=\"{0}\" height=\"30\" width=\"{1}\" classid=\"clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA\">", id, width);
            sb.Append("<param name=\"_ExtentX\" value=\"12700\">");
            sb.Append("<param name=\"_ExtentY\" value=\"847\">");
            sb.Append("<param name=\"AUTOSTART\" value=\"0\">");
            sb.Append("<param name=\"SHUFFLE\" value=\"0\">");
            sb.Append("<param name=\"PREFETCH\" value=\"0\">");
            sb.Append("<param name=\"NOLABELS\" value=\"0\">");
            sb.Append("<param name=\"CONTROLS\" value=\"ControlPanel,StatusBar\">");
            sb.Append("<param name=\"CONSOLE\" value=\"Clip\">");
            sb.Append("<param name=\"LOOP\" value=\"0\">");
            sb.Append("<param name=\"NUMLOOP\" value=\"0\">");
            sb.Append("<param name=\"CENTER\" value=\"0\">");
            sb.Append("<param name=\"MAINTAINASPECT\" value=\"0\">");
            sb.Append("<param name=\"BACKGROUNDCOLOR\" value=\"#000000\">");
            sb.Append("</object>");

            ContentType = "text/plain";
            context.HttpContext.Response.Write(sb.ToString());
        }
    }
}