using PCACalcula.Domain.Services;
using Xunit;

namespace PCACalcula.XUnitTest.tests
{
    public class GitHubTest
    {
        private GitHubService _gitHubService;

        public GitHubTest()
        {
            _gitHubService = new GitHubService();
        }
        [Fact]
        public void DeveRetornarUrlGit()
        {
            var resultadoEsperado = "https://github.com/PATRICIAARAUJOSISTEMAS/PCACalcula";

            var resultado = _gitHubService.GetUrl();

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
