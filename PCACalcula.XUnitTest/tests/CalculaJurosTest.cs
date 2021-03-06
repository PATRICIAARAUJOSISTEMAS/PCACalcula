﻿using Bogus;
using PCACalcula.Domain.Services;
using PCACalcula.XUnitTest.tests.Asserts;
using System.Linq;
using Xunit;
using PCACalcula.XUnitTest.tests.Utils;

namespace PCACalcula.XUnitTest.tests
{
    public class CalculaJurosTest
    {
        private readonly CalculaJurosService _calculaJurosService;
        private readonly Faker _faker;

        public CalculaJurosTest()
        {
            _calculaJurosService = new CalculaJurosService();
            _faker = new Faker();
        }

        [Fact]
        public void DeveCalcularJuros()
        {
            var valorInicial = 100.00M;
            var meses = 5;

            var resultadoEsperado = Utilidades.CalcularResultadoEsperado(valorInicial, meses);
            var resultado = _calculaJurosService.Calcula(valorInicial, meses);

            Assert.Equal(resultadoEsperado, resultado);

        }

        [Fact]
        public void DeveCalcularJurosRandom()
        {
            var valorInicial = _faker.Random.Decimal(0, 10000);
            var meses = _faker.Random.Int(1, 100);

            var resultadoEsperado = Utilidades.CalcularResultadoEsperado(valorInicial, meses);
            var resultado = _calculaJurosService.Calcula(valorInicial, meses);

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void DeveExibirMensagemAoInserirValorInicialIgualAZeroOuMenorQueZero(decimal valorInicial)
        {
            var meses = _faker.Random.Int(1, 100);

            var resultadoEsperado = Utilidades.CreateNotification("ValorInicial", "Você deve inserir um valor inicial maior que 0.");
            _calculaJurosService.Calcula(valorInicial, meses);

            resultadoEsperado.AssertNotificationPattern(_calculaJurosService.Notifications.FirstOrDefault());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void DeveExibirMensagemAoInserirMesesIgualAZero(int meses)
        {
            var valorInicial = _faker.Random.Decimal(meses, 10000);

            var resultadoEsperado = Utilidades.CreateNotification("Meses", "Você deve inserir um mês maior que 0.");
            _calculaJurosService.Calcula(valorInicial, 0);

            resultadoEsperado.AssertNotificationPattern(_calculaJurosService.Notifications.FirstOrDefault());
        }
    }
}
