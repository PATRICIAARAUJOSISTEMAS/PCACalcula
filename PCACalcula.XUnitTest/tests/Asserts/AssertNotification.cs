using prmToolkit.NotificationPattern;
using Xunit;

namespace PCACalcula.XUnitTest.tests.Asserts
{
    public static class AssertNotification
    {
        public static void AssertNotificationPattern(this Notification notificacaoEsperado, Notification notificacaoAtual)
        {
            Assert.Equal(notificacaoAtual.Property, notificacaoEsperado.Property);
            Assert.Equal(notificacaoAtual.Message, notificacaoEsperado.Message);
        }
    }
}
