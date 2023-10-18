using Microsoft.AspNetCore.Mvc;
using Moq;
using TechWiz.Controllers;
using TechWiz.Errors;
using TechWiz.Models;
using TechWiz.Repositories;
using TechWiz.Services;
using Xunit;

namespace TechWiz.Tests.ControllerTests
{
    public class UserControllerTests
    {

        [Fact]
        public async Task GetUser_ReturnsOkResult_WhenUserExists()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUserByIdAsync(It.IsAny<uint>())).ReturnsAsync(new User());

            var userController = new UserController(userServiceMock.Object);

            var result = await userController.GetUser("1");

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUser_ReturnsNotFoundError_WhenUserDoesNotExist()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUserByIdAsync(It.IsAny<uint>())).ReturnsAsync(() => null);

            var userController = new UserController(userServiceMock.Object);

            var result = await userController.GetUser("1");
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var error = Assert.IsType<NotFoundError>(notFoundResult.Value);
            Assert.Equal("UserNotFound", error.Error);
        }

        [Fact]
        public async Task GetUser_ReturnsBadRequest_WhenRequestedBodyIsMissing()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUserByIdAsync(It.IsAny<uint>())).ReturnsAsync(new User());

            var userController = new UserController(userServiceMock.Object);

            var result = await userController.GetUser("0");
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var error = Assert.IsType<InvalidFieldError>(badRequestResult.Value);
            Assert.Equal("InvalidId", error.Error);
        }

}}