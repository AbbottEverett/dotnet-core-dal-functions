using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

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
            throw new ArgumentException($"Unknown database type encounter: '{databaseType}'");
        }
    }
}