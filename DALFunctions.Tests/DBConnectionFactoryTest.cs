using System;
using Xunit;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DALFunctions.Tests
{
    public class DBConnectionFactoryTest
    {
        [Fact]
        public void ShouldGetSQLConnection()
        {
            //Given / Arrange
            var dbConnectionFactory = new DbConnectionFactory();
            var dbType = DatabaseType.SqlServer;
            var connectionString = "";

            //When / Act
            var sut = dbConnectionFactory.GetConnection(dbType, connectionString);

            //Then / Assert
            TestConnection(sut, connectionString);
        }

        [Fact]
        public void ShouldGetMySQLConnection()
        {
            // Arrange
            var dbConnectionFactory = new DbConnectionFactory();
            var dbType = DatabaseType.MySQL;
            var connectionString = "";

            // Act
            var sut = dbConnectionFactory.GetConnection(dbType, connectionString);

            // Assert
            TestConnection(sut, connectionString);
        }

        private void TestConnection(IDbConnection sut, string expectedConnectionString)
        {
            Assert.NotNull(sut);
            Assert.Equal(expectedConnectionString, sut.ConnectionString);
        }

    }
}