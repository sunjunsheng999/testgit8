using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insus.NET.Models
{
    public class News
    {
        public int News_nbr { get; set; }

        public string Subject { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime PublicDate { get; set; }
    }
}