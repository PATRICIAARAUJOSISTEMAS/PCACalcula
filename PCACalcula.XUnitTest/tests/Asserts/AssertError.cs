using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
