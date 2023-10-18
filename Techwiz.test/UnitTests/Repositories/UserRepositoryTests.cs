using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechWiz.Database;
using TechWiz.Models;
using TechWiz.Repositories;
using Xunit;

namespace Techwiz.Tests.RepositoryTests
{
    public class UserRepositoryTests
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepositoryTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("in_memory_schema")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _dbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser_WhenUserExists()
        {
            var expectedUser = new User{
                Id = 1, 
                Name = "John", 
                Email = "john@mail.com"
            };

            _dbContext.Users.Add(expectedUser);
            _dbContext.SaveChanges();

            var userRepository = new UserRepository(_dbContext);

            var result = await userRepository.GetUserByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(expectedUser.Name, result.Name);
            Assert.Equal(expectedUser.Email, result.Email);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            var userRepository = new UserRepository(_dbContext);

            var result = await userRepository.GetUserByIdAsync(999);

            Assert.Null(result);
        }
    }
}