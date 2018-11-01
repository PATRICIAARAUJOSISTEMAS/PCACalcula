

namespace PCACalcula.Domain.Interfaces
{
    public interface ICalculaJurosService : IServiceBase
    {
        float Calcula(decimal valorInicial, int meses);
    }
}
