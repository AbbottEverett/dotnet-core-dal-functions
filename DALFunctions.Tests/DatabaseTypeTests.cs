using System;
using Xunit;

namespace DALFunctions.Tests
{
    public class DatabaseTypeTests
    {
        [Fact]
        public void ShouldHavePostgreSQL()
        {
            var sut = DatabaseType.PostgreSQL;
            Assert.Equal("PostgreSQL", sut.Name);
        }
        
        [Fact]
        public void ShouldHaveMySql()
        {
            var sut = DatabaseType.MySQL;
            Assert.Equal("MySQL", sut.Name);
        }

        [Fact]
        public void ShouldHaveSqlServer()
        {
            var sut = DatabaseType.SqlServer;
            Assert.Equal("SqlServer", sut.Name);
        }

    }
}
