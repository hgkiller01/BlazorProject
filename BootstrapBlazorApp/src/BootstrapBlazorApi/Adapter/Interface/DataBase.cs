using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace BootstrapBlazorApi.Adapter.Interface
{
    public class DataBase
    {
        private IConfiguration _config;
        private string ConnStr;
        private SqlConnection conn;
        public DataBase()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            var configb = builder.Build();
            ConnStr = configb["ConnectionStrings:DefaultConnection"];
        }
    }
}
