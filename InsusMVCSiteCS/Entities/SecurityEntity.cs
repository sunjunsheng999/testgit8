using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insus.NET.Models;
using System.Data;

namespace Insus.NET.Entities
{
    public class SecurityEntity
    {
        BusinessBase objBusinessBase = new BusinessBase();

        public void ResetPassword(Security security)
        {
            Parameter[] parameter = { 
                                        new Parameter("@token",SqlDbType.NVarChar,-1,security.Token),
                                        new Parameter("@Password",SqlDbType.NVarChar,-1, security.Password)
                                    };
            objBusinessBase.ExecuteProcedure("usp_Member_ResetPassword", parameter);
        }
    }
}