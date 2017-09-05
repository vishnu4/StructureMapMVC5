using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StructureMapMVC5.Services
{
    public class BasicService : IBasicService
    {

        Models.IDBMethod _myMethod;
        public BasicService(Models.IDBMethod myMethod)
        {
            _myMethod = myMethod;
        }
        public string ExecuteDBMethod()
        {
            return _myMethod.ExecuteMethod();
        }
    }
}