using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insus.NET.Models
{
    public class FruitKind
    {
        public byte FruitKind_nbr { get; set; }

        [Required(ErrorMessage = "Category filed 请求值。")]
        public byte FruitCategory_nbr { get; set; }
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Name filed 请求值。")]
        public string KindName { get; set; }
    }
}

