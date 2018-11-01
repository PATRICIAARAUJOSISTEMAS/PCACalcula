﻿using Bogus;
using PCACalcula.Domain.Services;
using PCACalcula.XUnitTest.tests.Asserts;
using prmToolkit.NotificationPattern;
using System;
using System.Linq;
using Xunit;

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

            var resultadoExperado = CalcularResultadoExperado(valorInicial, meses);
            var resultado = _calculaJurosService.Calcula(valorInicial, meses);

            Assert.Equal(resultadoExperado, resultado);

        }

        [Fact]
        public void DeveCalcularJurosRandom()
        {
            var valorInicial = _faker.Random.Decimal(0, 10000);
            var meses = _faker.Random.Int(1, 100);

            var resultadoExperado = CalcularResultadoExperado(valorInicial, meses);
            var resultado = _calculaJurosService.Calcula(valorInicial, meses);

            Assert.Equal(resultadoExperado, resultado);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void DeveExibirMensagemAoInserirValorInicialIgualAZeroOuMenorQueZero(decimal valorInicial)
        {
            var meses = _faker.Random.Int(1, 100);

            var resultadoExperado = CreateNotification("ValorInicial", "Você deve inserir um valor inicial maior que 0.");
            _calculaJurosService.Calcula(valorInicial, meses);

            resultadoExperado.AssertNotificationPattern(_calculaJurosService.Notifications.FirstOrDefault());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void DeveExibirMensagemAoInserirMesesIgualAZero(int meses)
        {
            var valorInicial = _faker.Random.Decimal(meses, 10000);

            var resultadoExperado = CreateNotification("Meses", "Você deve inserir um mês maior que 0.");
            _calculaJurosService.Calcula(valorInicial, 0);

            resultadoExperado.AssertNotificationPattern(_calculaJurosService.Notifications.FirstOrDefault());
        }

        private float CalcularResultadoExperado(decimal valorInicial, int meses)
            =>  ((float)((double)valorInicial * Math.Pow(1.01, meses))).ToTwoPlaces();

        private Notification CreateNotification(string propriedade, string mensagem)
            => new Notification(propriedade, mensagem);
    }
}
