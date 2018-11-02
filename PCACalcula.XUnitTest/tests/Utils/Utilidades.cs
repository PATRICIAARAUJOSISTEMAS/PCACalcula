using PCACalcula.Models;
using prmToolkit.NotificationPattern;
using System;

namespace PCACalcula.XUnitTest.tests.Utils
{
    public static class Utilidades
    {
        public static float CalcularResultadoEsperado(decimal valorInicial, int meses)
           => ((float)((double)valorInicial * Math.Pow(1.01, meses))).ToTwoPlaces();

        public static Notification CreateNotification(string propriedade, string mensagem)
            => new Notification(propriedade, mensagem);

        public static CalculaJurosViewModel CreateViewModel(decimal valorInicial, int meses)
            => new CalculaJurosViewModel { ValorInicial = valorInicial, Meses = meses };
    }
}
