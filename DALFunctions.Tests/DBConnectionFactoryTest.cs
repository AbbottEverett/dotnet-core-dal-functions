using System;
using Xunit;

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
            Assert.NotNull(sut);
        }
    }
}