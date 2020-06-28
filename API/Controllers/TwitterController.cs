using System;

using System.Threading.Tasks;
using Ikkyo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ikkyo.Enums;
using API.AuthorizationInfo;
using RestSharp;
using API.Extensions;

namespace API.Controllers
{
    [Route("api/tweets/{searchText}")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        public string SearchString { get; set; }

        private string twitterUsername;
        private string twitterPassword;

        public IConfiguration Configuration { get; }

        private readonly AuthInfo authInfo;

        public TwitterController(IConfiguration configuration)
        {
            Configuration = configuration;
            twitterUsername = Configuration["Twitter:Username"];
            twitterPassword = Configuration["Twitter:Password"];
            authInfo = new AuthInfo(twitterUsername, twitterPassword);
        }

        [HttpGet()]
        public async Task<Tweet> GetTweets(string searchText)
        {
            Uri baseURI = new Uri("https://api.twitter.com/1.1/search/tweets.json");

            using (RestDisposable client = new RestDisposable(baseURI))
            {
                string q = "q=" + searchText;

                ResultType result_type = ResultType.popular;

                string lang = "&lang=English";

                string latitude = "39.035147";
                string longitude = "-77.503127";
                string radius = "3000";
                string geocode = "&geocode=" + latitude + "," + longitude + "," + radius;

                string count = "&count=99";

                int since_id = 99999;

                string max_id = "";//"&max_id=100";

                string include_entities = "&include_entities=true";

                string _base = "https://api.twitter.com/1.1/search/tweets.json";
                //string resource = "?" + q + geocode + lang + "&result_type=" + result_type.ToString() +
                //count + max_id + include_entities;
                string resource = "?" + q;

                TwitterAuthController authCon = new TwitterAuthController(Configuration);
                //Consider changing this to custom Bearer Token class or Dictionary
                Tuple<String, String> token = authCon.BearerToken(twitterUsername, twitterPassword);

                var request = new RestRequest(baseURI + resource, Method.GET);
                
                request.AddHeader("Content-Type", "application / json");

                request.AddHeader("Authorization", token.Item1 + " " + token.Item2);

                var response = client.Execute(request);
                var tweetResponse = client.Execute<Tweet>(request);
                var tweetStatusList = tweetResponse.Data.Statuses;
                var tweetSearchMetadata = tweetResponse.Data.SearchMetadata;
                var tweet = new Tweet(tweetStatusList, tweetSearchMetadata);
                
                return tweet;
            }
        }

    }
}