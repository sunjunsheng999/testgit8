using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Insus.NET.Entities
{
    public class MailingListEntity
    {
        BusinessBase objBusinessBase = new BusinessBase();

        public DataTable GetDistributeMailList()
        {
            return objBusinessBase.GetDataToDataSet("usp_MailingList_DistributeMailList").Tables[0];
        }
    }
}


