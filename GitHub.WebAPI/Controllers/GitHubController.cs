using GitHubIntegration;
using GitHubIntegration.Data;
using Microsoft.AspNetCore.Mvc;
using Octokit;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHub.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGithubService _githubService; 
        public GitHubController(IGithubService githubService)
        {
            _githubService = githubService;
        }
    
        // GET: api/<GitHubController>
        [HttpGet]
        public async Task<Portfolio> Get()
        {
            return await _githubService.GetPortfolio();
        }

        // GET api/<GitHubController>/5
        [HttpGet("/search")]
        public async Task<List<Repository>> SearchRepositories(string? nameRepository, string? language, string? userName)
        {
            return await _githubService.SearchRepositories(nameRepository, language, userName);
        }

        // POST api/<GitHubController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GitHubController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GitHubController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
