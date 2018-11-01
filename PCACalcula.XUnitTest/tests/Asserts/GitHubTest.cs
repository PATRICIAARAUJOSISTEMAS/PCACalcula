using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PCACalcula.XUnitTest.tests.Asserts
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
