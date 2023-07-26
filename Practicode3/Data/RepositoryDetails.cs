using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubIntegration.Data
{
    public class RepositoryDetails
    {
        public string Language { get; set; }
        public DateTime LastCommit { get; set; }
        public int numOfStars { get; set; }
        public int numOfPullRequests { get; set; }
        public string Url { get; set; }
        public RepositoryDetails(string language, DateTime lastCommit, int numOfStars, int numOfPullRequests, string url)
        {
            Language = language;
            LastCommit = lastCommit;
            this.numOfStars = numOfStars;
            this.numOfPullRequests = numOfPullRequests;
            Url = url;
        }
    }
}
