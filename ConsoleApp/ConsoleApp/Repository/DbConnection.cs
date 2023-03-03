using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace ConsoleApp
{
    public static class DbConnection
    {
        public static string GetConnectionString()
        {
            var host = "Host=localhost:5412;";
            var username = "Username=postgres;";
            var password = "Password=140208;";
            var database = "Database=facilities";

            return host + username + password + database;
        }
    }
}