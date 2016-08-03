using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insus.NET;
using Insus.NET.Models;

namespace Insus.NET.Entities
{
    public class FlexPaperEntity
    {
        public List<FlexPaper> GetSwfFile(FlexPaper fp)
        {
            string TemporaryDirectory = "~/Temp/";
            string fID = fp.ID.ToString ();

            string fileName = Guid.NewGuid().ToString();
            string filePdf = TemporaryDirectory + fID + ".pdf";
            string fileSwf = TemporaryDirectory + fileName + ".swf";           

            using (System.Diagnostics.Process p = new System.Diagnostics.Process())
            {
                p.StartInfo.FileName = HttpContext.Current.Server.MapPath("~/BIN/PDF2SWF.exe");
                p.StartInfo.Arguments = " -t " + 
                    HttpContext.Current.Server.MapPath(filePdf) + 
                    " -s flashversion=9  -o " +  
                    HttpContext.Current.Server.MapPath(fileSwf);

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;

                p.Start();
                p.WaitForExit();
            }

            List<FlexPaper> oo = new List<FlexPaper>();            
            oo.Add(new FlexPaper { swfFile = "/Temp/" + fileName + ".swf" });
            return oo;
        }
    }
}