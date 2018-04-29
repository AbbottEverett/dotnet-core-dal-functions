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
    }
}
