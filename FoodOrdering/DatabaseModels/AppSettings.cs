using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdering.DatabaseModels
{
    public class AppSettings
    {
        SqlConnection con;

        public AppSettings()
        {
            var configuration = GetConfiguration();
            con = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }

        public SqlConnection GetDBSring()
        {
            return con;
        }

        public string GetHashe(string name)
        {
            var configuration = GetConfiguration();
            return configuration.GetSection("Secrets").GetSection(name).Value;
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
