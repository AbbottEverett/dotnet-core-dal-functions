using System;

namespace DALFunctions
{
    public sealed class DatabaseType
    {
        public int Id { get; }
        public string Name { get; }
        private DatabaseType(int id, string name)
        {
            Id = id;
            Name = name;

        }

        public static DatabaseType Unknown = new DatabaseType(0, "Unknown");
        public static DatabaseType SqlServer = new DatabaseType(0, "SqlServer");
        public static DatabaseType MySQL = new DatabaseType(0, "MySQL");
        public static DatabaseType PostgreSQL = new DatabaseType(0, "PostgreSQL");

    }
}
