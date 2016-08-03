using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insus.NET.Models;
using System.Data;
using Insus.NET.Utilities;

namespace Insus.NET.Entities
{
    public class FileLibraryEntity
    {
        BusinessBase objBusinessBase = new BusinessBase();

        public void Insert(FileLibrary fl)
        {
            Parameter[] parameter = {                                        
                                        new Parameter ("@OldFileName",SqlDbType.NVarChar,-1,fl.OldFileName),
                                        new Parameter ("@NewFileName",SqlDbType.NVarChar,-1,fl.NewFileName),
                                        new Parameter ("@Extension",SqlDbType.NVarChar,-1,fl.Extension),
                                        new Parameter ("@Size",SqlDbType.Int,4,fl.Size)
                                    };
            objBusinessBase.ExecuteProcedure("usp_FileLibrary_Insert", parameter);
        }

        public List<FileLibrary> GetAllUploadFiles()
        {
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_FileLibrary_GetAll").Tables[0];
            return DataEntity.DataTableConvertToList<FileLibrary>(dt);
        }


        //此方法于2014-Mar-21 10:15 重构。
        public List<FileLibrary> GetAllUploadFilesByPrimaryKey(FileLibrary fl)
        {
            //Parameter[] parameter = { 
            //                            new Parameter ("@FileLibrary_nbr",SqlDbType.Int,4,fl.FileLibrary_nbr)
            //                        };
            //DataTable dt = objBusinessBase.GetDataToDataSet("usp_FileLibrary_GetByPrimaryKey", parameter).Tables[0];           

            DataTable dt = GetUploadFileByPrimaryKey(fl);
            return DataEntity.DataTableConvertToList<FileLibrary>(dt);
        }

        public DataTable GetUploadFileByPrimaryKey(FileLibrary fl)
        {
            Parameter[] parameter = { 
                                        new Parameter ("@FileLibrary_nbr",SqlDbType.Int,4,fl.FileLibrary_nbr)
                                    };
            return objBusinessBase.GetDataToDataSet("usp_FileLibrary_GetByPrimaryKey", parameter).Tables[0];
        }

        public void Delete(FileLibrary fl)
        {
            Parameter[] parameter = { 
                                        new Parameter ("@FileLibrary_nbr",SqlDbType.Int,4,fl.FileLibrary_nbr)
                                    };
            objBusinessBase.ExecuteProcedure("usp_FileLibrary_Delete", parameter);
        }

        public void Update(FileLibrary fl)
        {
            Parameter[] parameter = {                                        
                                        new Parameter ("@FileLibrary_nbr",SqlDbType.Int,4,fl.FileLibrary_nbr),
                                        new Parameter ("@OldFileName",SqlDbType.NVarChar,-1,fl.OldFileName),
                                        new Parameter ("@NewFileName",SqlDbType.NVarChar,-1,fl.NewFileName),
                                        new Parameter ("@Extension",SqlDbType.NVarChar,-1,fl.Extension),
                                        new Parameter ("@Size",SqlDbType.Int,4,fl.Size)
                                    };
            objBusinessBase.ExecuteProcedure("usp_FileLibrary_Update", parameter);
        }
    }
}
