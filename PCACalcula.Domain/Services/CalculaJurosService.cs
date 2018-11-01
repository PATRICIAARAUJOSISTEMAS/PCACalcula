using PCACalcula.Domain.Interfaces;
using System;

namespace PCACalcula.Domain.Services
{
    public class CalculaJurosService : ServiceBase, ICalculaJurosService
    {
        public float Calcula(decimal valorInicial, int meses)
        {
            ValidarParametros(valorInicial, meses);
            if (IsInvalid())
                return 0;

            return ((float)((double)valorInicial * Math.Pow(1.01, meses))).ToTwoPlaces();
        }

        private void ValidarParametros(decimal valorInicial, int meses)
        {
            if(valorInicial <= 0)
                AddNotification("ValorInicial", "Você deve inserir um valor inicial maior que 0.");

            if (meses <= 0)
                AddNotification("Meses", "Você deve inserir um mês maior que 0.");
                
        }

    }
}