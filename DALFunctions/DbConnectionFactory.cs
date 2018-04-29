using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Npgsql;
using Pomelo.Data.MySql;

namespace DALFunctions
{
    public class DbConnectionFactory
    {
        public IDbConnection GetConnection(DatabaseType databaseType, string connectionString)
        {
            if (databaseType == DatabaseType.SqlServer) 
            {
                return new SqlConnection(connectionString);
            } 
            else if (databaseType == DatabaseType.MySQL)
            {
                return new MySqlConnection(connectionString);
            }
            else if (databaseType == DatabaseType.PostgreSQL)
            {
                return new NpgsqlConnection(connectionString);
            }

            throw new ArgumentException($"Unknown database type encountered: '{databaseType}'");
        }
    }
}