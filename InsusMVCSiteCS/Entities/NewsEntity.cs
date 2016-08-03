using Insus.NET.Models;
using Insus.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Insus.NET.Entities
{
    public class NewsEntity
    {

        BusinessBase objBusinessBase = new BusinessBase();
        public List<News> GetAll()
        {
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_News_GetAll").Tables[0];
            return DataEntity.DataTableConvertToList<News>(dt);
        }
    }
}