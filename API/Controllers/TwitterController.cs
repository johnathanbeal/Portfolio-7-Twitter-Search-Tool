using System;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Domain.Enums;
using RestSharp;
using Domain.Interface;

namespace API.Controllers
{
    [Route("api/tweets/{searchText}")]
    [ApiController]
    public class TwitterController : ControllerBase
    {

        public string SearchString { get; set; }

        private readonly ITwitterService _twitterService;

        public TwitterController(IConfiguration configuration, ITwitterService twitterService)
        {          
            _twitterService = twitterService;
        }

        [HttpGet()]
        public async Task<Tweet> GetTweets(string searchText)
        {
            var baseUri = new Uri("https://api.twitter.com/1.1/search/tweets.json");

            var client = new RestClient(baseUri);

            var request = new RestRequest(baseUri, Method.GET);

            request.AddParameter("q", searchText, ParameterType.QueryString);

            request.AddHeader("Content-Type", "application / json");

            request.AddHeader("Authorization", "Bearer " + _twitterService.GetBearerToken());

            return client.Execute<Tweet>(request).Data;


            //using (RestDisposable client = new RestDisposable(baseUri, Method.GET))
            //{
            //    string q = "q=" + searchText;

            //    ResultType result_type = ResultType.popular;

            //    string lang = "&lang=English";

            //    string latitude = "39.035147";
            //    string longitude = "-77.503127";
            //    string radius = "3000";
            //    string geocode = "&geocode=" + latitude + "," + longitude + "," + radius;

            //    string count = "&count=99";

            //    int since_id = 99999;

            //    string max_id = "";//"&max_id=100";

            //    string include_entities = "&include_entities=true";

            //    string _base = "https://api.twitter.com/1.1/search/tweets.json";
                
            //    string resource = "?" + q;

            //    var request = new RestRequest(baseURI + resource, Method.GET);
                
                

            //    var response = client.Execute(request);
            //    var tweetResponse = client.Execute<Tweet>(request);
            //    var tweetStatusList = tweetResponse.Data.Statuses;
            //    var tweetSearchMetadata = tweetResponse.Data.SearchMetadata;
            //    var tweet = new Tweet(tweetStatusList, tweetSearchMetadata);
                
            //    return tweet;
            //}
        }

    }
}