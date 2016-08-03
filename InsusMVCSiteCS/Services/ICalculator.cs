using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Insus.NET.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalculator" in both code and config file together.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        decimal Add(decimal number1, decimal number2);

        [OperationContract]
        decimal Subtract(decimal number1, decimal number2);

        [OperationContract]
        decimal Multiply(decimal number1, decimal number2);

        [OperationContract]
        decimal Divide(decimal number1, decimal number2);
    }
}
