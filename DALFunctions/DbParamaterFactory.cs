using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Npgsql;
using Pomelo.Data.MySql;

namespace DALFunctions
{
    public class DbParamaterFactory
    {
        protected readonly DatabaseType _DatabaseType;

        public DbParamaterFactory(DatabaseType databaseType)
        {
            this._DatabaseType = databaseType;
        }

        public DbParameter GetParamater(KeyValuePair<string, object> kvp)
            => this.GetParamater(kvp.Key, kvp.Value);

        public DbParameter GetParamater(string key, object value)
        {
            if (_DatabaseType == DatabaseType.MySQL) 
            {
                return new MySqlParameter(key, value);
            } 
            else if (_DatabaseType == DatabaseType.SqlServer) 
            {
                return new SqlParameter(key, value);
            } 
            else if (_DatabaseType == DatabaseType.PostgreSQL) 
            {
                return new NpgsqlParameter(key, value);
            }
            throw new Exception($"Invalid database type of '{_DatabaseType}'");
        }
    }
}