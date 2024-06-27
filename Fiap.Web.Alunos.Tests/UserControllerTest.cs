using AutoMapper;
using Fiap.Desafio.Api.Controllers;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;
using Fiap.Desafio.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Web.Alunos.Tests
{
    public class UserControllerTest
    {

        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserController _userController;
        public UserControllerTest() {
            _userServiceMock = new Mock<IUserService>();
            _mapperMock = new Mock<IMapper>();
            _userController = new UserController(_userServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task add_ReturnsOkResponse_UserController()
        {
            // Arrange
            var addUserDto = new AddUserDto {};
            var userModel = new UserModel();
            var personModel = new PersonModel();

            _mapperMock.Setup(mapper => mapper.Map(addUserDto, It.IsAny<UserModel>())).Returns(userModel);
            _mapperMock.Setup(mapper => mapper.Map<PersonModel>(addUserDto)).Returns(personModel);
            _userServiceMock.Setup(service => service.Add(It.IsAny<UserModel>()));

            // Act
            var result = await Task.Run(() => _userController.add(addUserDto));

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task get_ReturnsOkResponse_UserController()
        {
            // Arrange
            int id = 1;
            var userModel = new UserModel();
            _userServiceMock.Setup(service => service.Get(id)).Returns(userModel);

            // Act
            var result = await Task.Run(() => _userController.Get(id));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task delete_ReturnsOkResponse_UserController()
        {
            // Arrange
            long id = 1;
            _userServiceMock.Setup(service => service.Delete(id));

            // Act
            var result = await Task.Run(() => _userController.Delete(id));

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
