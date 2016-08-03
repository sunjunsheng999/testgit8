using Insus.NET;
using Insus.NET.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insus.NET.Entities
{
    public class FruitCategoryEntity
    {
        BusinessBase objBusinessBase = new BusinessBase();

        public IEnumerable<FruitCategory> GetAllFruitCategory()
        {
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_FruitCategory_GetAll").Tables[0];
            return DataTableConvertToEnumerable(dt);
        }

        public IEnumerable<FruitCategory> GetFruitCategoryByPrimaryKey(byte fruitCategory_nbr)
        {
            Parameter[] parameter = {
                                        new Parameter ("@Fruitcategory_nbr",SqlDbType.TinyInt,1,fruitCategory_nbr)
                                   };

            DataTable dt = objBusinessBase.GetDataToDataSet("usp_FruitCategory_GetByPrimarykey", parameter).Tables[0];
            return DataTableConvertToEnumerable(dt);
        }

        private IEnumerable<FruitCategory> DataTableConvertToEnumerable(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                yield return new FruitCategory
                {
                    FruitCategory_nbr = row.Field<byte>("FruitCategory_nbr"),
                    CategoryName = row.Field<string>("CategoryName")
                };
            }
        }

        public void Insert(FruitCategory fruitCategory)
        {
            Parameter[] parameter = {
                                        new Parameter ("@CategoryName",SqlDbType.NVarChar,-1,fruitCategory.CategoryName)
                                   };
            objBusinessBase.ExecuteProcedure("usp_FruitCategory_Insert", parameter);
        }

        public void Update(FruitCategory fruitCategory)
        {
            Parameter[] parameter = {
                                        new Parameter ("@Fruitcategory_nbr",SqlDbType.TinyInt,1,fruitCategory.FruitCategory_nbr),
                                        new Parameter ("@CategoryName",SqlDbType.NVarChar,-1,fruitCategory.CategoryName)
                                   };
            objBusinessBase.ExecuteProcedure("usp_FruitCategory_Update", parameter);
        }

        public void Delete(FruitCategory fruitCategory)
        {
            Parameter[] parameter = {
                                        new Parameter ("@Fruitcategory_nbr",SqlDbType.TinyInt,1,fruitCategory.FruitCategory_nbr)
                                   };
            objBusinessBase.ExecuteProcedure("usp_FruitCategory_Delete", parameter);
        }

        public List<SelectListItem> SelectLists()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_FruitCategory_GetAll").Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                items.Add(new SelectListItem
                {
                    Text = row.Field<string>("CategoryName"),
                    Value = row.Field<byte>("FruitCategory_nbr").ToString()
                });
            }
            return items;
        }        
    }
}


