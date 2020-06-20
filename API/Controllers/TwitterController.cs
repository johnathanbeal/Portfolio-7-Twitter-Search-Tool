using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Ikkyo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ikkyo.Enums;
using System.Runtime.CompilerServices;
using API.AuthorizationInfo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.Routing.Matching;
using RestSharp;
using API.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using System.IO;
using static Ikkyo.Entities.Tweet;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Deserializers;
using Newtonsoft.Json.Linq;
using API.NewtonsoftIkkyo;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController //: ControllerBase
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

        [HttpGet]
        public async Task<Tweet> GetTweets()
        {
            Uri baseURI = new Uri("https://api.twitter.com/1.1/search/tweets.json");

            using (RestDisposable client = new RestDisposable(baseURI))
            {
                string q = "q=Trump";

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

                string url = String.Format(_base + resource);
                Console.WriteLine("\nThe URI is ${url}");

                TwitterAuthController authCon = new TwitterAuthController(Configuration);
                //Consider changing this to custom Bearer Token class or Dictionary
                Tuple<String, String> token = authCon.BearerToken(twitterUsername, twitterPassword);

                var request = new RestRequest(baseURI + resource, Method.GET);
                
                request.AddHeader("Content-Type", "application / json");

                //Authorization
                request.AddHeader("Authorization", token.Item1 + " " + token.Item2);

                var response = client.Execute(request);
                var tweetResponse = client.Execute<Tweet>(request);
                var jObject = JObject.Parse(response.Content);

                Newtonsoft.Json.Linq.JToken[] statuses = jObject.GetValue("statuses").ToArray<Newtonsoft.Json.Linq.JToken>();
                JObject status1 = (JObject)statuses[0];
                JToken createdAt = status1["created_at"];
                string _statuses = jObject.GetValue("statuses").ToString();
                Tweet _object = SimpleJson.DeserializeObject<Tweet>(response.Content);
                
                //JToken memberName = jObject["members"].First["name"]; EXAMPLE

                Newtonsoft.Json.Linq.JToken status = jObject.GetValue("statuses").ToString();
                var values = jObject.GetValue("search_metadata").ToString();
                 
                Tweet tweet = new Tweet();
                return tweet;
            }
        }
    }
}