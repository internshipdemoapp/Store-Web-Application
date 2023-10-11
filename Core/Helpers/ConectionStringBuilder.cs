using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class ConnectionStringBuilder
    {
        public static string GenerateConnectionString(WebApplicationBuilder builder)
        {
            var dbSettings = builder.Configuration.GetSection("DbSecrets").Get<DbConnectionSettings>();

            string connectionString = $"Server={dbSettings.DbHost};Port=3306;Database={dbSettings.DbName};User Id={dbSettings.DbUser};Password={dbSettings.DbPassword};Connect Timeout=30;SslMode=None";

            return connectionString;
        }
    }
    public class DbConnectionSettings
    {
        public string DbName { get; set; }
        public string DbHost { get; set; }
        public string DbUser { get; set; }
        public string DbPassword { get; set; }
    }
}
