using Moq;
using TechWiz.Models;
using TechWiz.Repositories;
using TechWiz.Services;
using Xunit;

namespace TechWiz.Tests.ServiceTests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser_WhenUserExists()
        {
            uint userId = 1;
            var expectedUser = new User{
                Id = userId,
                Name = "Joseph",
                Email = "JosephStalindo@mail.com",
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(expectedUser);

            var userService = new UserService(userRepositoryMock.Object);

            var result = await userService.GetUserByIdAsync(userId);

            Assert.NotNull(result);
            Assert.Equal(expectedUser.Name, result.Name);
            Assert.Equal(expectedUser.Email, result.Email);

        }


        [Fact]
        public async Task GetUserByIdAsync_ReturnsNull_WhenUserDoesNotExists()
        {
            uint userId = 1;

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(userId)).ReturnsAsync(() => null);

            var userService = new UserService(userRepositoryMock.Object);

            var result = await userService.GetUserByIdAsync(userId);

            Assert.Null(result);

        }
    }
}