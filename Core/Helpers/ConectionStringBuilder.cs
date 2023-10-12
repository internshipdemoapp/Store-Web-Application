﻿using Microsoft.AspNetCore.Builder;
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
        //public static IConfiguration Configuration { get; set; }
        //public static string GenerateConnectionString(IConfiguration? configuration = null)
        //{
        //    if (configuration != null)
        //        Configuration = configuration;

        //    var dbSettings = Configuration.GetSection("DbSecrets").Get<DbConnectionSettings>();

        //    string connectionString = $"Server={dbSettings.DbHost};Port=3306;Database={dbSettings.DbName};User Id={dbSettings.DbUser};Password={dbSettings.DbPassword};Connect Timeout=30;SslMode=None";

        //    return connectionString;

        //}
        public static string GenerateConnectionString()
        {
            var dbHost = Environment.GetEnvironmentVariable("DbHost");
            var dbUser = Environment.GetEnvironmentVariable("DbUsername");
            var dbPass = Environment.GetEnvironmentVariable("DbPassword");
            var dbName = Environment.GetEnvironmentVariable("DbName");

            if (dbHost == null && dbUser == null && dbPass == null && dbName == null)
                return "";

            string connectionString = $"Server={dbHost};Port=3306;Database={dbName};User Id={dbUser};Password={dbPass};Connect Timeout=30;SslMode=None";

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
