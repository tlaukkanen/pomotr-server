using System;
using Microsoft.EntityFrameworkCore;
using Pomotr.Server.Database;
using Xunit;

namespace PomotrService.Tests
{
    public class ApplicationDbContextTests
    {
        public ApplicationDbContextTests()
        {            
        }

        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Pomotr")
                .Options;
            using(ApplicationDbContext db = new ApplicationDbContext(options))
            {
                var users = db.Users;
                var errands = db.Errands;
                //Assert.Equal(,1);

            }
            
        }
    }
}
