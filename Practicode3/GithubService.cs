using GitHubIntegration.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubIntegration
{
    public class GithubService:IGithubService
    {
        private readonly GitHubClient _client;
        private readonly GitHubIntegrationOptions _options;
        private readonly IConfiguration _configuration;
        public GithubService(IOptions<GitHubIntegrationOptions> options,IConfiguration configuration)
        {
            _configuration= configuration;
            _client = new GitHubClient(new ProductHeaderValue("my-github-app"));
            _options = options.Value;
            _options.Token = _configuration["GitHubToken"].ToString();
            _options.UserName = _configuration["UserName"].ToString();
            _client.Credentials = new Credentials(_options.UserName,_options.Token);
        }
        public async Task<int> GetUserFollowersAsync(string userName)
        {
            var user = await _client.User.Get(userName);
            return user.Followers;
        }
        public async Task<List<Repository>> SearchRepository(string search)
        {
            var request = new SearchRepositoriesRequest(search);
            var result = await _client.Search.SearchRepo(request);
            return result.Items.ToList();
        }
        public async Task<Portfolio> GetPortfolio()
        {
            Portfolio result=new Portfolio();
            result.MyRepositories = (await _client.Repository.GetAllForCurrent()).ToList();
            result.UserName= _options.UserName;
            return result;
        }
        public async Task<List<Repository>> SearchRepositories(string? nameRepository,string? language,string? userName)
        {
            var search = "is:public ";
            if (!string.IsNullOrEmpty(nameRepository))
                search += $"name:{nameRepository}";
            if (!string.IsNullOrEmpty(language))
                search += $"language:{language}";
            if (!string.IsNullOrEmpty(userName))
                search += $"user:{userName}";
            return await SearchRepository(search);
        }
    }
}
