using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insus.NET.Interfaces
{
    interface IAutoCompletable
    {
        DataTable GetWord(string inputString);
    }
}
