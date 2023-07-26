using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubIntegration
{
    public static class Extensions
    {
        public static void AddGitHubIntegration(this IServiceCollection services , Action<GitHubIntegrationOptions> configureoptions)
        {
            services.Configure(configureoptions);
            services.AddScoped<IGithubService, GithubService>();
        }
    }
}
