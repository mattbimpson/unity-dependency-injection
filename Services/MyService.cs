using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services
{
    public class MyService : IService
    {
        public string test = "test";

        public string Test()
        {
            return "dependency injection working!";
        }
    }
}
