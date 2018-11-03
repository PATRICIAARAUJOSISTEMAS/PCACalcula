using PCACalcula.IntegrationTest.Infra;
using Xunit;
using PCACalcula.XUnitTest.tests.Utils;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using prmToolkit.NotificationPattern;
using System.Linq;
using PCACalcula.XUnitTest.tests.Asserts;
using System.Net.Http;

namespace PCACalcula.IntegrationTest.Test
{
    public class CalculaJurosTest : TestFixture
    {
        private StringContent _content;

        public CalculaJurosTest()
        {
            _url = $"{_urlBase}/PCACalcula/CalculaJuros/CalculaJuros?";
            _content = new StringContent("");
        }

        [Fact]
        public async Task DeveCalcularJuros()
        {
            var responseController = new
            {
                Data = 0F
            };
            var viewModel = Utilidades.CreateViewModel(100, 5);
            var resultadoEsperado = Utilidades.CalcularResultadoEsperado(viewModel.ValorInicial, viewModel.Meses);

            var response = await _client.GetAsync($"{_url}&valorInicial={viewModel.ValorInicial}&meses={viewModel.Meses}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var responseData = JsonConvert.DeserializeAnonymousType(responseString, responseController);

            Assert.Equal(resultadoEsperado, responseData.Data);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public async Task DeveExibirMensagemAoInserirValorInicialIgualAZeroOuMenorQueZero(decimal valorInicial)
        {
            var responseController = new
            {
                errors = new List<Notification>()
            };

            var viewModel = Utilidades.CreateViewModel(valorInicial, _faker.Random.Int(1, 100));
            var resultadoEsperado = Utilidades.CreateNotification("ValorInicial", "Você deve inserir um valor inicial maior que 0.");

            var response = await _client.GetAsync($"{_url}&valorInicial={viewModel.ValorInicial}&meses={viewModel.Meses}");

            var responseString = await response.Content.ReadAsStringAsync();

            var responseData = JsonConvert.DeserializeAnonymousType(responseString, responseController);

            resultadoEsperado.AssertNotificationPattern(responseData.errors.FirstOrDefault());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public async Task DeveExibirMensagemAoInserirMesesIgualAZeroAsync(int meses)
        {
            var responseController = new
            {
                errors = new List<Notification>()
            };

            var viewModel = Utilidades.CreateViewModel(_faker.Random.Decimal(0,100), meses);
            var resultadoEsperado = Utilidades.CreateNotification("Meses", "Você deve inserir um mês maior que 0.");

            var response = await _client.GetAsync($"{_url}&valorInicial={viewModel.ValorInicial}&meses={viewModel.Meses}");

            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeAnonymousType(responseString, responseController);

            resultadoEsperado.AssertNotificationPattern(responseData.errors.FirstOrDefault());
        }

        [Fact]
        public async Task DeveCalcularJurosRandom()
        {
            var responseController = new
            {
                Data = 0F
            };
            var viewModel =  Utilidades.CreateViewModel(100, _faker.Random.Int(1, 12));
            var resultadoEsperado = Utilidades.CalcularResultadoEsperado(viewModel.ValorInicial, viewModel.Meses);

            var response = await _client.GetAsync($"{_url}&valorInicial={viewModel.ValorInicial}&meses={viewModel.Meses}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var responseData = JsonConvert.DeserializeAnonymousType(responseString, responseController);

            Assert.Equal(resultadoEsperado, responseData.Data);
        }

        [Fact]
        public async Task DeveRetornarErroAoInserirHttpDelete()
        {
            var responseExpected = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            var response = await _client.DeleteAsync(_url);
            AssertError.AssertErro(responseExpected, response);
        }

        [Fact]
        public async Task DeveRetornarErroAoInserirHttpPost()
        {
            var responseExpected = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            var response = await _client.PostAsync(_url, _content);
            AssertError.AssertErro(responseExpected, response);
        }
        [Fact]
        public async Task DeveRetornarErroAoInserirHttpPut()
        {
            var responseExpected = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            var response = await _client.PutAsync(_url, _content);
            AssertError.AssertErro(responseExpected, response);
        }
    }
}
