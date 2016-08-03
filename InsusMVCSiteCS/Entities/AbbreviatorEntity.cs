using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insus.NET.Models;
using System.Data;
using Insus.NET.Utilities;
using Insus.NET.Interfaces;

namespace Insus.NET.Entities
{
    public class AbbreviatorEntity : IAutoCompletable 
    {
        BusinessBase objBusinessBase = new BusinessBase();

        public DataTable GetWord(string inputString)
        {
            Parameter[] parameter = { 
                                            new Parameter("@InputString",SqlDbType.NVarChar,-1,inputString)
                                        };
            return objBusinessBase.GetDataToDataSet("usp_Abbreviator_GetAbbrWord", parameter).Tables[0];
        }
    }
}