using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Insus.NET.Utilities
{
    public class Thumbnail
    {
        public static void GenerateThumbnail(string source, string destination, int maxWidth, int maxHeight)
        {
            System.Drawing.Image orginalImage = System.Drawing.Image.FromFile(source);           

            int originalWidth = orginalImage.Width;
            int originalHeight = orginalImage.Height;
            
            int thumbnailWidth, thumbnailHeight; 
            Resize(originalWidth, originalHeight,  maxWidth,  maxHeight, out thumbnailWidth, out thumbnailHeight);

            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(thumbnailWidth, thumbnailHeight);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);

            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            graphics.DrawImage(orginalImage, 0, 0, thumbnailWidth, thumbnailHeight);
           
            bitmap.Save(destination);
        }
            
        private static void Resize(int origWidth, int origHeight, int maxWidth, int maxHeight, out int sizedWidth, out int sizedHeight)
        {
            if (origWidth < maxWidth && origHeight < maxHeight)
            {
                sizedWidth = origWidth;
                sizedHeight = origHeight;
                return;
            }

            sizedWidth = maxWidth;
            sizedHeight = (int)((double)origHeight / origWidth * sizedWidth + 0.5);

            if (sizedHeight > maxHeight)
            {
                sizedHeight = maxHeight;
                sizedWidth = (int)((double)origWidth / origHeight * sizedHeight + 0.5);
            }
        }
    }
}