using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessDemo.Web
{
    public static class DatabaseHelpers
    {
        public static string GetPostgresConnectionString()
        {

            var dbname = "productsdb";

            if (string.IsNullOrEmpty(dbname)) return null;

            var username = "postgres";
            var password = "sasa";
            var hostname = "10.0.2.99";//
            var port = "5432";


            return $"User ID={username};Password={password};Host={hostname};Port={port};Database={dbname};";
        }
        public static string GetRDSConnectionString()
        {

            var dbname = "registration";

            if (string.IsNullOrEmpty(dbname)) return null;

            var username = "postgres";
            var password = "sasasasa";
            var hostname = "hexquotedb.cmb1qrijkowb.eu-central-1.rds.amazonaws.com";
            var port = "5432";


            return $"User ID={username};Password={password};Host={hostname};Port={port};Database={dbname};";
        }
    }
}
