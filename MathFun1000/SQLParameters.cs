using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathFun1000
{
    public class SQLParameters
    {
        private string key;
        public string Key
        {
            get
            {
                return key;
            }
        }


        private object param;
        public object Param
        {
            get 
            {
                return param;
            }
        }

        public SQLParameters(string _key, object _param)
        {
            key = _key;
            param = _param;
        }
    }
}