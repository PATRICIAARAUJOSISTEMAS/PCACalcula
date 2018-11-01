using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PCACalcula.XUnitTest.tests.Asserts
{
    public static class AssertNotification
    {
        public static void AssertNotificationPattern(this Notification notificacaoExperado, Notification notificacaoAtual)
        {
            Assert.Equal(notificacaoAtual.Property, notificacaoExperado.Property);
            Assert.Equal(notificacaoAtual.Message, notificacaoExperado.Message);
        }
    }
}
