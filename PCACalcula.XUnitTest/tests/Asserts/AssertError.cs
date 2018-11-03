using System.Net.Http;
using Xunit;

namespace PCACalcula.XUnitTest.tests.Asserts
{
    public static class AssertError
    {
        public static void AssertErro(HttpResponseMessage responseExpected, HttpResponseMessage response)
        {
            Assert.Equal(responseExpected.StatusCode, response.StatusCode);
        }
    }
}
