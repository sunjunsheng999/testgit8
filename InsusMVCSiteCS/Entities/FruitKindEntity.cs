using Insus.NET;
using Insus.NET.Models;
using Insus.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Insus.NET.Entities
{
    public class FruitKindEntity
    {
        BusinessBase objBusinessBase = new BusinessBase();

        public List<FruitKind> GetAllFruitKind()
        {
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_FruitKind_GetAll").Tables[0];
           
            return DataEntity.DataTableConvertToList<FruitKind>(dt);
        }

        public List<FruitKind> GetFruitKindByPrimaryKey(byte fruitKind_nbr)
        {
            Parameter[] parameter = {
                                        new Parameter ("@FruitKind_nbr",SqlDbType.TinyInt,1,fruitKind_nbr)
                                   };
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_FruitKind_GetByPrimaryKey", parameter).Tables[0];

            return DataEntity.DataTableConvertToList<FruitKind>(dt);
        }

        public void Insert(FruitKind fruitKind)
        {
            Parameter[] parameter = {
                                        new Parameter ("@FruitCategory_nbr",SqlDbType.TinyInt,1,fruitKind.FruitCategory_nbr),
                                        new Parameter ("@KindName",SqlDbType.NVarChar,-1,fruitKind.KindName)
                                   };
            objBusinessBase.ExecuteProcedure("usp_FruitKind_Insert", parameter);
        }

        public void Update(FruitKind fruitKind)
        {
            Parameter[] parameter = {
                                        new Parameter ("@FruitKind_nbr",SqlDbType.TinyInt,1,fruitKind.FruitKind_nbr),
                                        new Parameter ("@FruitCategory_nbr",SqlDbType.TinyInt,1,fruitKind.FruitCategory_nbr),
                                        new Parameter ("@KindName",SqlDbType.NVarChar,-1,fruitKind.KindName)
                                   };
            objBusinessBase.ExecuteProcedure("usp_FruitKind_Update", parameter);
        }

        public void Delete(FruitKind fruitKind)
        {
            Parameter[] parameter = {
                                        new Parameter ("@FruitKind_nbr",SqlDbType.TinyInt,1,fruitKind.FruitKind_nbr)
                                   };
            objBusinessBase.ExecuteProcedure("usp_FruitKind_Delete", parameter);
        }

        public List<SelectListItem> SelectLists(byte? fruitCategory_nbr)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            Parameter[] parameter = { 
                                        new Parameter ("@FruitCategory_nbr",SqlDbType.TinyInt,1,fruitCategory_nbr)
                                    };
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_FruitKind_GetByFruitCategory",parameter).Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                items.Add(new SelectListItem
                {
                    Text = row.Field<string>("KindName"),
                    Value = row.Field<byte>("FruitKind_nbr").ToString()
                });
            }
            return items;
        }
    }
}