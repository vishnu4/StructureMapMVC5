using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureMapMVC5.Models
{
    public class SeondDBMethod : IDBMethod
    {
        public string ExecuteMethod()
        {
            return nameof(SeondDBMethod);
        }
    }
}