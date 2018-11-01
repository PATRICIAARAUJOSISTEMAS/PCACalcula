using PCACalcula.Domain.Interfaces;

namespace PCACalcula.Domain.Services
{
    public class GitHubService : IGitHubService
    {
        public string GetUrl()
            => "https://github.com/PATRICIAARAUJOSISTEMAS/PCACalcula";
    }
}