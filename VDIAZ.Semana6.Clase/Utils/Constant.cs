using System;
using System.Collections.Generic;
using System.Text;

namespace VDIAZ.Semana6.Clase.Utils
{
    public class Constant
    {
        public class Services
        {
            private static readonly string SERVICE_BASE_URL = "http://192.168.100.37:8080/api";
            public static readonly string SERVICE_USERS = string.Format("{0}/{1}", SERVICE_BASE_URL, "users");
            public static readonly string SERVICE_ACTIVITIES = string.Format("{0}/{1}", SERVICE_BASE_URL, "activity");
        }

        public class Method
        {
            public static readonly string GET = "GET";
            public static readonly string POST = "POST";
            public static readonly string PUT = "PUT";
            public static readonly string DELETE = "DELETE";
        }
        
    }
}
