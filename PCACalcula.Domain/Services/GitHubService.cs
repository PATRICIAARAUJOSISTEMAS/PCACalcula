using PCACalcula.Domain.Interfaces;
using prmToolkit.NotificationPattern;

namespace PCACalcula.Domain.Services
{
    public class GitHubService : Notifiable, IGitHubService
    {
        public string GetUrl()
            => "https://github.com/PATRICIAARAUJOSISTEMAS/PCACalcula";
    }
}