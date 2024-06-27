using System;
using System.Threading.Tasks;
using AutoMapper;
using Fiap.Desafio.Api.Controllers;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Fiap.Web.Alunos.Tests
{
    public class AuthControllerTest
    {

        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly AuthController _authController;


        public AuthControllerTest() {
            _userServiceMock = new Mock<IUserService>();
            _mapperMock = new Mock<IMapper>();
            _authController = new AuthController(_userServiceMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task get_returnResponseOkAuth()
        {
            // Arrange
            var loginDto = new LoginDto { Login = "testuser", password = "password" };
            _userServiceMock.Setup(service => service.IsLoginAuthorized(It.IsAny<LoginDto>())).Returns(true);

            // Act
            var result = await Task.Run(() => _authController.Login(loginDto));

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult?.StatusCode);
        }
    }
}