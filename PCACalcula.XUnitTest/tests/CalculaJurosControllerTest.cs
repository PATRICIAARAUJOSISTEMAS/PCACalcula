using Bogus;
using Moq;
using PCACalcula.Controllers;
using PCACalcula.Domain.Interfaces;
using PCACalcula.XUnitTest.tests.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PCACalcula.XUnitTest.tests
{
    public class CalculaJurosControllerTest
    {
        private readonly Mock<ICalculaJurosService> _serviceMock;
        private readonly Faker _faker;

        public CalculaJurosControllerTest()
        {
            _serviceMock = new Mock<ICalculaJurosService>();
            _faker = new Faker();
        }

        [Fact]
        public void DeveCalcularJuros()
        {
            var valorInicial = 100.00M;
            var meses = 5;

            var resultadoExperado = Utilidades.CalcularResultadoExperado(valorInicial, meses);

            _serviceMock.Setup(f => f.Calcula
            (
                It.IsAny<decimal>(),
                It.IsAny<int>()
             ))
              .Returns(resultadoExperado);

            var calculaJurosController = new CalculaJurosController(_serviceMock.Object);

            var parameter = Utilidades.CreateViewModel(valorInicial, meses);
            var actionResult = calculaJurosController.CalculaJuros(parameter);

            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public void DeveCalcularJuosRandom()
        {
            var valorInicial = _faker.Random.Decimal(0, 10000);
            var meses = _faker.Random.Int(1, 100);

            var resultadoExperado = Utilidades.CalcularResultadoExperado(valorInicial, meses);

            _serviceMock.Setup(f => f.Calcula
            (
                It.IsAny<decimal>(),
                It.IsAny<int>()
            ))
             .Returns(resultadoExperado);

            var calculaJurosControleer = new CalculaJurosController(_serviceMock.Object);

            var parameter = Utilidades.CreateViewModel(valorInicial, meses);
            var actionResult = calculaJurosControleer.CalculaJuros(parameter);

            Assert.IsType<OkObjectResult>(actionResult);
        }
    }
}
