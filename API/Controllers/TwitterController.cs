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

            request.AddHeader("Content-Type", "application/json");

            request.AddHeader("Authorization", "Bearer " + _twitterService.GetBearerToken());

            var tweet = client.Execute<Tweet>(request).Data;
            
            return tweet;
        }

    }
}