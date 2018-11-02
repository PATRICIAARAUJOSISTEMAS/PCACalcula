using Bogus;
using Moq;
using PCACalcula.Controllers;
using PCACalcula.Domain.Interfaces;
using PCACalcula.XUnitTest.tests.Utils;
using Xunit;
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

            var resultadoEsperado = Utilidades.CalcularResultadoEsperado(valorInicial, meses);

            IncludeSetup(resultadoEsperado);

            var calculaJurosController = new CalculaJurosController(_serviceMock.Object);

            var parameter = Utilidades.CreateViewModel(valorInicial, meses);
            var actionResult = calculaJurosController.CalculaJuros(parameter);

            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Fact]
        public void DeveCalcularJurosRandom()
        {
            var valorInicial = _faker.Random.Decimal(0, 10000);
            var meses = _faker.Random.Int(1, 100);

            var resultadoEsperado = Utilidades.CalcularResultadoEsperado(valorInicial, meses);

            IncludeSetup(resultadoEsperado);

            var calculaJurosControleer = new CalculaJurosController(_serviceMock.Object);

            var parameter = Utilidades.CreateViewModel(valorInicial, meses);
            var actionResult = calculaJurosControleer.CalculaJuros(parameter);

            Assert.IsType<OkObjectResult>(actionResult);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void DeveExibirMensagemAoInserirValorInicialIgualAZeroOuMenorQueZero(decimal valorInicial)
        {
            var meses = _faker.Random.Int(1, 100);

            var calculaJurosControleer = new CalculaJurosController(_serviceMock.Object);

            var parameter = Utilidades.CreateViewModel(valorInicial, meses);
            var actionResult = calculaJurosControleer.CalculaJuros(parameter);

            Assert.IsType<BadRequestObjectResult>(actionResult);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void DeveExibirMensagemAoInserirMesesIgualAZero(int meses)
        {
            var valorInicial = _faker.Random.Decimal(meses, 10000);

            var calculaJurosControleer = new CalculaJurosController(_serviceMock.Object);

            var parameter = Utilidades.CreateViewModel(valorInicial, meses);
            var actionResult = calculaJurosControleer.CalculaJuros(parameter);

            Assert.IsType<BadRequestObjectResult>(actionResult);

        }

        private void IncludeSetup(float resultadoEsperado)
        {
            _serviceMock.Setup(f => f.Calcula
            (
                It.IsAny<decimal>(),
                It.IsAny<int>()
            ))
             .Returns(resultadoEsperado);

            _serviceMock.Setup(f => f.IsValid()).Returns(true);
        }
    }
}
