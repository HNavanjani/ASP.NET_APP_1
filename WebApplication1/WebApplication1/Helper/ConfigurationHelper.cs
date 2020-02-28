using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.Helper
{
    public class ConfigurationHelper
    {
        public static String getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString.ToString();

        }
    }
}