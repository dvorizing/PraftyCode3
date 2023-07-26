 using GitHubIntegration;
using GitHubIntegration.Data;
using Microsoft.Extensions.Caching.Memory;
using Octokit;

namespace GitHub.WebAPI.CachedServices
{
    public class CachedGitHubService : IGithubService
    {
        private readonly IGithubService _githubService;
        private readonly IMemoryCache _memoryCache;
        private const string GetPortfolioKey = "GetPortfolioKey";
        public CachedGitHubService(IGithubService githubService,IMemoryCache memoryCache)
        {
            _githubService = githubService;
            _memoryCache = memoryCache;
        }
        public async Task<Portfolio> GetPortfolio()
        {
            if (_memoryCache.TryGetValue(GetPortfolioKey, out Portfolio portfolio))
                return portfolio;
            var cacheOptions=new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(30));
            portfolio= await _githubService.GetPortfolio();
            _memoryCache.Set(GetPortfolioKey, portfolio);
            return portfolio;
        }

        public async Task<int> GetUserFollowersAsync(string username)
        {
            return await _githubService.GetUserFollowersAsync(username);
        }

        public async Task<List<Repository>> SearchRepositories(string? nameRepository, string? language, string? userName)
        {
            return await _githubService.SearchRepositories(nameRepository, language, userName);
        }

        public async Task<List<Repository>> SearchRepository(string search)
        {
            return await _githubService.SearchRepository(search);
        }
    }
}
