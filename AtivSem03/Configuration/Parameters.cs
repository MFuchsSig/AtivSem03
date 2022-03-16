using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtivSem03.Configuration
{
    public class Parameters
    {
        public static string getConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["Empresa"].ConnectionString;
        }
    }
}