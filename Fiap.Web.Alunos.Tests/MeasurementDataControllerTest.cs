using AutoMapper;
using Fiap.Desafio.Api.Controllers;
using Fiap.Desafio.Api.Dtos;
using Fiap.Desafio.Api.Models;
using Fiap.Desafio.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Web.Alunos.Tests
{
    public class MeasurementDataControllerTest
    {
        private readonly Mock<IMeasurementDataService> _measurementDataServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly MeasurementDataController _measurementDataController;

        public MeasurementDataControllerTest() {
            _measurementDataServiceMock = new Mock<IMeasurementDataService>();
            _mapperMock = new Mock<IMapper>();
            _measurementDataController = new MeasurementDataController(_measurementDataServiceMock.Object, _mapperMock.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "testuser"),
                new Claim("sub", "testuserid"),
            }, "mock"));

            _measurementDataController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

        }

        [Fact]
        public void get_returnResponseOkMeasurementData_WithAuthorize()
        {
            // Arrange
            var addMeasureDto = new AddMeasureDto {};
            var recordMeasurementModel = new RecordMeasurementModel();

            _mapperMock.Setup(mapper => mapper.Map<AddMeasureDto, RecordMeasurementModel>(addMeasureDto, It.IsAny<RecordMeasurementModel>())).Returns(recordMeasurementModel);
            _measurementDataServiceMock.Setup(service => service.Add(It.IsAny<RecordMeasurementModel>()));

            // Act
            var result = _measurementDataController.Add(addMeasureDto);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }







    }
}
