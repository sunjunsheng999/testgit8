using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Insus.NET.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Calculator" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Calculator.svc or Calculator.svc.cs at the Solution Explorer and start debugging.
    public class Calculator : ICalculator
    {
        public decimal Add(decimal number1, decimal number2)
        {
            return number1 + number2;
        }

        public decimal Subtract(decimal number1, decimal number2)
        {
            return number1 - number2;
        }

        public decimal Multiply(decimal number1, decimal number2)
        {
            return number1 * number2;
        }

        public decimal Divide(decimal number1, decimal number2)
        {
            return number1 / number2;
        }
    }
}
