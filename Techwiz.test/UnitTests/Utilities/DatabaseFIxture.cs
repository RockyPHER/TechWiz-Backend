using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechWiz.Database;

namespace TechWiz.Tests.Utilities
{
    public class DatabaseFixture : IDisposable
    {
        public ApplicationDbContext Context;

        public DatabaseFixture()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("in_memory_schema")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            Context = new ApplicationDbContext(options);
            Context.Database.EnsureCreated();
        }
        
        
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}