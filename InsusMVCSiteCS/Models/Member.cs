using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insus.NET.Models
{
    public class Member
    {
        public int Member_nbr { get; set; }
         
        public string Account { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
    }
}


