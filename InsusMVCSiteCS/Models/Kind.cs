using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Insus.NET.Models
{
    [DataContract(Name = "Kind")]
    public class Kind
    {
        [DataMember(IsRequired = true, Name = "FruitKind_nbr")]
        public byte FruitKind_nbr { get; set; }

        [DataMember(IsRequired = true, Name = "FruitCategory_nbr")]
        public byte FruitCategory_nbr { get; set; }      

        [DataMember(IsRequired = true, Name = "KindName")]
        public string KindName { get; set; }
    }
}