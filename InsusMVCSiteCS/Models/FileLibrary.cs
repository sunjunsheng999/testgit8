using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insus.NET.Models
{
    public class FileLibrary
    {

        public int FileLibrary_nbr { get; set; }
        public string OldFileName { get; set; }
        public string  NewFileName { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }      
        public DateTime UploadedTime { get; set; }
    }
}