using GitHubIntegration.Data;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubIntegration
{
    public interface IGithubService
    {
        Task<int> GetUserFollowersAsync(string username);
        Task<List<Repository>> SearchRepository(string search);
        Task<Portfolio> GetPortfolio();
        Task<List<Repository>> SearchRepositories(string? nameRepository, string? language, string? userName);


    }
}
