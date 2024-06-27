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
    public class IndexControllerTest
    {
        private readonly Mock<IIndexService> _indexServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IndexController _indexController;

        public IndexControllerTest()
        {
            _indexServiceMock = new Mock<IIndexService>();
            _mapperMock = new Mock<IMapper>();
            _indexController = new IndexController(_indexServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task get_returnResponseOkIndex()
        {
            // Arrange
            var addIndexDto = new AddIndexDto {};
            var resourceIndexModel = new ResourceIndexModel();

            _mapperMock.Setup(mapper => mapper.Map<ResourceIndexModel>(addIndexDto)).Returns(resourceIndexModel);

            // Act
            var result = _indexController.Add(addIndexDto);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
