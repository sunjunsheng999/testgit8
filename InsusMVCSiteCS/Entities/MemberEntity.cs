using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insus.NET;
using Insus.NET.Models;
using System.Data;
using Insus.NET.Utilities;

namespace Insus.NET.Entities
{
    public class MemberEntity
    {
        BusinessBase objBusinessBase = new BusinessBase();

        public void Register(Member member)
        {
            Parameter[] parameter = { 
                                        new Parameter("@Account",SqlDbType.NVarChar,-1,member.Account),
                                        new Parameter("@Password",SqlDbType.NVarChar,-1,member.Password),
                                        new Parameter("@Email",SqlDbType.NVarChar,-1,member.Email)
                                    };
            objBusinessBase.ExecuteProcedure("usp_Member_Register", parameter);
        }

        public List<Member> LoginVerify(Member member)
        {
            Parameter[] parameter = { 
                                        new Parameter("@Account",SqlDbType.NVarChar,-1,member.Account),
                                        new Parameter("@Password",SqlDbType.NVarChar,-1,member.Password)
                                    };
            DataTable dt = objBusinessBase.GetDataToDataSet("usp_Member_LoginVerifyAndGetInfo",
                parameter).Tables[0];
            return DataEntity.DataTableConvertToList<Member>(dt);
        }

        public void RequestPassword(Member member)
        {
            Parameter[] parameter = { 
                                        new Parameter("@Account",SqlDbType.NVarChar,-1,member.Account),
                                        new Parameter("@Email",SqlDbType.NVarChar,-1,member.Email)
                                    };
            objBusinessBase.ExecuteProcedure("usp_Member_RequestPassword", parameter);
        }
    }
}



