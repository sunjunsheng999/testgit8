using Insus.NET.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Insus.NET.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FruitKind" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FruitKind.svc or FruitKind.svc.cs at the Solution Explorer and start debugging.
    public class FruitKind : IFruitKind
    {
        FruitKindEntity fke = new FruitKindEntity();
       
        public IEnumerable<Insus.NET.Models.FruitKind> GetAll()
        {
            return fke.GetAllFruitKind();
        }


        public void Create(byte fruitCategory_nbr, string kindName)
        {
            Insus.NET.Models.FruitKind fk = new Models.FruitKind();
            fk.FruitCategory_nbr = fruitCategory_nbr;
            fk.KindName = kindName;
            fke.Insert(fk);
        }

        public IEnumerable<Insus.NET.Models.FruitKind> GetByPrimaryKey(byte fruitKind_nbr)
        {
            return fke.GetFruitKindByPrimaryKey(fruitKind_nbr);
        }

        public void Update(Insus.NET.Models.Kind k)
        {
           Insus.NET.Models.FruitKind fk = new Models.FruitKind();    
           fk.FruitKind_nbr = k.FruitKind_nbr;
           fk.FruitCategory_nbr = k.FruitCategory_nbr;           
           fk.KindName = k.KindName;   

            fke.Update(fk);            
        }
       
    }
}