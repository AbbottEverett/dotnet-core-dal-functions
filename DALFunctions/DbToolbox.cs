
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.Data.MySql;


namespace DALFunctions
{
    public class DbToolbox
    {
        protected readonly DbConnection _dbConnection;
        protected readonly DbParamaterFactory _dbParameterFactory;
        protected int _CommandTimeOut = 600;

        public DbToolbox(DbConnection dbConnection, DbParamaterFactory dbParamaterFactory)
        {
            _dbConnection = dbConnection;
            _dbParameterFactory = dbParamaterFactory;
        }

        protected virtual DbCommand GetDbCommand(DbConnection connection, CommandType commandType, string commandText)
        {
            var result = connection.CreateCommand();
            result.Connection = connection;
            result.CommandText = commandText;
            result.CommandTimeout = _CommandTimeOut;
            result.CommandType = commandType;
            return result;
        }

        private DbDataReader GetSqlDataReaderFromCommand(DbCommand command)
        {
            return command.ExecuteReader();
        }

        private IEnumerable<DbDataRecord> GetRecordsFromReader(DbDataReader reader)
        {
            var results = new List<DbDataRecord>();

            foreach (DbDataRecord record in reader)
            {
                results.Add(record);
            }
            return results;
        }

        public IEnumerable<DbDataRecord> ExecuteRawSqlReturnDataRecords(
            string rawSql, IEnumerable<KeyValuePair<string, object>> parameters = null)
        {
            using (DbCommand command = GetDbCommand(_dbConnection, CommandType.Text, rawSql))
            {
                AddParameters(command.Parameters, parameters);
                var reader = GetSqlDataReaderFromCommand(command);
                return GetRecordsFromReader(reader);
            }
        }

        private void AddParameters(DbParameterCollection parameterCollection, IEnumerable<KeyValuePair<string, object>> parameters)
        {
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> kvp in parameters)
                {
                    var dbParameter = _dbParameterFactory.GetParamater(kvp.Key, kvp.Value);
                    parameterCollection.Add(dbParameter);
                }
            }
        }

    }
}