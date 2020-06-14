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
            using (var client = new HttpClient())
            {
                string q = "q=moms";

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
                string resource = "?" + q + geocode + lang + "&result_type=" + result_type.ToString() +
                count + max_id + include_entities;

                string url = String.Format(_base);
                Console.WriteLine("\nThe URI is ${url}");

                AuthController authCon = new AuthController(Configuration);

                client.BaseAddress = new Uri(_base);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await authCon.BearerToken(twitterUsername, twitterPassword));

                var response = await client.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    //get output

                    //pass or process output
                }
                return new Tweet();
            }
        }
    }
}