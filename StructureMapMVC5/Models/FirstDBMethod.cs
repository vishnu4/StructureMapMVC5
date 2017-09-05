using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureMapMVC5.Models
{
    public class FirstDBMethod : IDBMethod
    {
        public string ExecuteMethod()
        {
            return nameof(FirstDBMethod);
        }
    }
}