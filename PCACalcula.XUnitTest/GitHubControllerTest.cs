using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PCACalcula.Controllers;
using PCACalcula.Domain.Interfaces;
using Xunit;

namespace PCACalcula.XUnitTest
{
    public class GitHubControllerTest
    {
        private Mock<IGitHubService> _serviceMock;
        private Faker _faker;

        public GitHubControllerTest()
        {
            _serviceMock = new Mock<IGitHubService>();
            _faker = new Faker();
        }

        [Fact]
        public void DeveRetornarUrlGit()
        {
            var resultadoEsperado = "https://github.com/PATRICIAARAUJOSISTEMAS/PCACalcula";

            IncludeSetup(resultadoEsperado);

            var controller = new GitHubController(_serviceMock.Object);
            var actionResult = controller.ShowMetheCode();

            Assert.IsType<OkObjectResult>(actionResult);

        }

        private void IncludeSetup(string resultadoEsperado)
        {
            _serviceMock.Setup(f => f.GetUrl()).Returns(resultadoEsperado);
            _serviceMock.Setup(f => f.IsValid()).Returns(true);
        }
    }
}
