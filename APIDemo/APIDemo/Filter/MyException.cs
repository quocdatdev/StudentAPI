using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDemo.Filter
{
    public class MyException : Exception
    {
        public MyException(string msg) : base (msg) { }
    }
}