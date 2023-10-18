using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechWiz.Database;
using TechWiz.Models;
using TechWiz.Repositories;
using TechWiz.Tests.Utilities;
using Xunit;

namespace Techwiz.Tests.RepositoryTests
{   
    public class UserRepositoryTests : IClassFixture<DatabaseFixture>, IDisposable
    {
        private readonly DatabaseFixture _fixture;
        private readonly ApplicationDbContext _context;

        public UserRepositoryTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _context = _fixture.Context;
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser_WhenUserExists()
        {
            var expectedUser = new User{
                Name = "John", 
                Email = "john@mail.com"
            };

            _context.Users.Add(expectedUser);
            _context.SaveChanges();

            var userRepository = new UserRepository(_context);

            var AsyncFunc = await userRepository.GetUserByIdAsync(1);

            Assert.NotNull(AsyncFunc);
            Assert.Equal(expectedUser.Name, AsyncFunc.Name);
            Assert.Equal(expectedUser.Email, AsyncFunc.Email);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsNull_WhenUserDoesNotExist()
        {
            var userRepository = new UserRepository(_context);

            var AsyncFunc = await userRepository.GetUserByIdAsync(999);

            Assert.Null(AsyncFunc);
        }

        [Fact]
        public async Task CreateUserAsync_ReturnsUser_WhenUserIsCreated()
        {
            var userRepository = new UserRepository(_context);

            var expectedUser = new User{
                Name = "James",
                Email = "xxx@gamer.com"
            };

            var AsyncFunc = await userRepository.CreateUserAsync(expectedUser);
            var foundUser = await _context.FindAsync<User>(AsyncFunc.Id);

            Assert.NotNull(foundUser);
            Assert.Equal(expectedUser.Id, foundUser.Id);
            Assert.Equal(expectedUser.Name, foundUser.Name);
            Assert.Equal(expectedUser.Email, foundUser.Email);

        }

        [Fact]
        public async Task CreateUserAsync_ThrowsError_WhenUserIsInvalid()
        {
            var userRepository = new UserRepository(_context);

            var expectedUser = new User
            {
                Name = string.Empty,
                Email = string.Empty
            };

            var AsyncFunc = userRepository.CreateUserAsync(expectedUser);
            
            await Assert.ThrowsAsync<Exception>(async () => await AsyncFunc);

        }
    }
}