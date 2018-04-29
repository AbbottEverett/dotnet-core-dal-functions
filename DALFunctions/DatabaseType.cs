using System;
using System.Collections.Generic;

namespace DALFunctions
{
    public sealed class DatabaseType
    {
        private static readonly IDictionary<string, DatabaseType> DatabaseTypes = new Dictionary<string, DatabaseType>();

        public int Id { get; }
        public string Name { get; }
        private DatabaseType(int id, string name)
        {
            Id = id;
            Name = name;

            DatabaseTypes[name] = this;
        }

        public static DatabaseType Unknown = new DatabaseType(0, "Unknown");
        public static DatabaseType SqlServer = new DatabaseType(1, "SqlServer");
        public static DatabaseType MySQL = new DatabaseType(2, "MySQL");
        public static DatabaseType PostgreSQL = new DatabaseType(3, "PostgreSQL");


        public static explicit operator DatabaseType(string name) 
        {
            return DatabaseTypes.ContainsKey(name)
                ? DatabaseTypes[name]
                : Unknown;
        }

    }
}
