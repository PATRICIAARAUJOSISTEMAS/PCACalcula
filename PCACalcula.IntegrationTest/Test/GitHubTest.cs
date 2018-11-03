using Bogus;
using Newtonsoft.Json;
using PCACalcula.Domain.Services;
using PCACalcula.IntegrationTest.Infra;
using PCACalcula.XUnitTest.tests.Asserts;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PCACalcula.XUnitTest.tests
{
    public class GitHubTest : TestFixture
    {
        private StringContent _content;

        public GitHubTest()
        {
            _url = $"{_urlBase}/PCACalcula/GitHub/ShowMetheCode";
            _content = new StringContent("");
        }

        [Fact]
        public async Task DeveRetornarUrlGitAsync()
        {
            var responseController = new
            {
                Data = ""
            };

            var resultadoEsperado = "https://github.com/PATRICIAARAUJOSISTEMAS/PCACalcula";

            var response = await _client.GetAsync($"{_url}");
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
