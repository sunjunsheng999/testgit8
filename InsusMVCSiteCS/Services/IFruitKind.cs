using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Insus.NET.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFruitKind" in both code and config file together.
    [ServiceContract]
    public interface IFruitKind
    {
        [OperationContract]

        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetAll")]
        IEnumerable<Insus.NET.Models.FruitKind> GetAll();

        [OperationContract]
        [WebInvoke(
                   Method = "POST",
                   BodyStyle = WebMessageBodyStyle.WrappedRequest,
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "Create")]
        void Create(byte fruitCategory_nbr, string kindName);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetByPrimaryKey")]
        IEnumerable<Insus.NET.Models.FruitKind> GetByPrimaryKey(byte fruitKind_nbr);
        
        [OperationContract]
        [WebInvoke(Method = "POST",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "Update")]
        void Update(Insus.NET.Models.Kind k);       
    }
}


