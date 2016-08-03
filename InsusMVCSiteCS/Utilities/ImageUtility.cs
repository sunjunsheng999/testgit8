using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Insus.NET.Utilities
{
    public class ImageUtility
    {
        public static string Base64String(string virtualPath)
        {
            string PhysicalPath = HttpContext.Current.Server.MapPath(virtualPath);
            FileStream fileStream = new FileStream(PhysicalPath, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[(int)fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            return Convert.ToBase64String(data);
        }

        public static bool IsImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            var stream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            try
            {
                stream.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream, true, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsImage1(string virtualPath)
        {
            string PhysicalPath = HttpContext.Current.Server.MapPath(virtualPath);
            FileStream fileStream = new FileStream(PhysicalPath, FileMode.Open, FileAccess.Read);
         
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(fileStream, true, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static bool IsImage(HttpPostedFileBase fpfb)
        {
            try
            {
                System.Drawing.Image image = System.Drawing.Image.FromStream(fpfb.InputStream, true, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}