using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventosCSW.DAL.Tools
{
    public class DBConnection
    {
        public static string urlSQLServer = ConfigurationManager.ConnectionStrings["EventosCSW.WEB.Properties.Settings.DBCx"].ToString();
    }
}
