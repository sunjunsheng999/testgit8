using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Insus.NET.Utilities
{
    public class FileUtility
    {
        public static byte[] GetFileData(string fullFilePath)
        {            
            if (!File.Exists(fullFilePath))
                throw new FileNotFoundException("文件不存在。", fullFilePath);

            return File.ReadAllBytes(fullFilePath);
        }
    }
}