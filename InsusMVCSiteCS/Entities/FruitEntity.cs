using Insus.NET;
using Insus.NET.Models;
using Insus.NET.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Insus.NET.Entities
{
    public class FruitEntity
    {
        BusinessBase objBusinessBase = new BusinessBase();

        public List<Fruit> GetAllFruit()
        {
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_Fruit_GetAll").Tables[0];
            return DataEntity.DataTableConvertToList<Fruit>(dt);
        }

        public List<Fruit> GetFruitByPrimarykey(byte? fruit_nbr)
        {
            Parameter[] parameter = { 
                                        new Parameter("@Fruit_nbr",SqlDbType.TinyInt,1,fruit_nbr)
                                    };
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_Fruit_GetByPrimaryKey", parameter).Tables[0];
            return DataEntity.DataTableConvertToList<Fruit>(dt);
        }

        public void Insert(Fruit fruit)
        {
            Parameter[] parameter = { 
                                        new Parameter ("@FruitKind_nbr",SqlDbType.TinyInt,1,fruit.FruitKind_nbr),
                                        new Parameter ("@FruitName",SqlDbType.NVarChar,-1,fruit.FruitName)
                                    };
            objBusinessBase.ExecuteProcedure("usp_Fruit_Insert", parameter);
        }

        public void Update(Fruit fruit)
        {
            Parameter[] parameter = { 
                                     new Parameter ("@Fruit_nbr",SqlDbType.TinyInt,1,fruit.Fruit_nbr),
                                     new Parameter ("@FruitKind_nbr",SqlDbType.TinyInt,1,fruit.FruitKind_nbr),
                                     new Parameter ("@FruitName",SqlDbType.NVarChar,-1,fruit.FruitName)
                                    };
            objBusinessBase.ExecuteProcedure("usp_Fruit_Update", parameter);
        }

        public void Delete(Fruit fruit)
        {
            Parameter[] parameter = { 
                                        new Parameter ("@Fruit_nbr",SqlDbType.TinyInt,1,fruit.Fruit_nbr)
                                    };
            objBusinessBase.ExecuteProcedure("usp_Fruit_Delete", parameter);
        }

        public List<Fruit> GetAllFruitForReport()
        {
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_Fruit_GetAllReport").Tables[0];
            return DataEntity.DataTableConvertToList<Fruit>(dt);
        }

        public List<Fruit> SearchFruitForReport(string categoryName,string kindName, string fruitName)
        {
            Parameter[] parameter = { 
                                     new Parameter ("@CategoryName",SqlDbType.NVarChar,-1,categoryName),
                                     new Parameter ("@KindName",SqlDbType.NVarChar,-1,kindName),
                                     new Parameter ("@FruitName",SqlDbType.NVarChar,-1,fruitName)
                                    };

            DataTable dt = objBusinessBase.GetDataToDataSet("usp_Fruit_SearchReport", parameter).Tables[0];
            return DataEntity.DataTableConvertToList<Fruit>(dt);
        }
    }
}


