using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
//using Microsoft.OneGet.Utility.Extensions;
using System;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
//using Broker.Manage.Core;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterAuthController : ControllerBase
    {
        public IConfiguration ICon { get; }

        private string twitterUsername;
        private string twitterPassword;

        public TwitterAuthController(IConfiguration icon)
        {
            ICon = icon;
            twitterUsername = ICon["Twitter:Username"];
            twitterPassword = ICon["Twitter:Password"];
        }

        public async Task<String> BearerToken(string _username, string _password)
        {
            //URI
            string baseURI = "https://api.twitter.com/oauth2/token";
            //Authorization
            string username = _username;
            string password = _password;
            //Headers
            string content_type = "application/x-www-form-urlencoded";
            string connection = "keep-alive";
            object scope = "";
            object resource = "";
            string contentType = "application/json";
            string accept = "application/json";
            string grant_type = "client_credentials";

            var client = new RestClient(baseURI);
            var request = new RestRequest(Method.POST);

            request.Parameters.Clear();
            request.AddParameter("Authorization", "Basic bklVSzA5ZUg1TUYyQTJhQ2RxbWhoNEl1bjpTSFpaUmx0cHgyc2xYQUN1T0E1Qng1NGxpRmRZVVEwYlVSeGVuRU5GVFZmOXI5Z00yVw==");
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("grant_type", grant_type);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            IRestResponse response = client.Execute(request);//multiple attempts with varied headers and parameters return code 99, even after logging out of Twitter

            //How Tim Pool makes this work
            //using a mix of types, not just RestSharp
            
            //declare key/username

            //declare secret/password

            //concatenate key and secret with a ':' in between

            //Convert to Base 64

            // ?? ServicePointManager

            // Add authorization header

            // set protocol version

            // set timeout

            // set max idle time

            // set connection limit

            // set content type

            // keep alive

            // set rest method

            // set Accept

            // fancy code for setting grant_type

            // set decompression

            // set cookie container

            // return request

            return "";

            //Check out Tim Corey

            //Use HttpClient

            //Or Use RestSharp
        }

        //blog.timwheeler.io/authenticating-with-twitter-using-restsharp/
        //Tim Wheeler wrote the code below
        private SecureString _consumerKey;
        private SecureString _consumerSecret;
        private SecureString _accessToken;
        private CookieContainer _cookieContainer;
        private const string AuthUrl = "https://api.twitter.com/oauth2/token";
        //public TwitterAuthController(string consumerKey, string consumerSecret, string bearerToken)
        //{
        //    //_consumerKey = consumerKey?.ToSecureString();
        //    //_consumerSecret = consumerSecret?.ToSecureString();
        //    //_accessToken = bearerToken?.ToSecureString();
        //    //_cookieContainer = new CookieContainer();
        //}
        //private HttpWebRequest CreateAuthenticationRequest(IWebProxy)
        //{
        //    var key = System.Web.HttpUtility.UrlEncode(_consumerKey.ToInsecureString());
        //    return HttpWebRequest(null);
        //}

        //public static SecureString ToSecureString(this string source)
        //{
        //    if (string.IsNullOrWhiteSpace(source))
        //    {
        //        return null;
        //    }
        //    var result = new SecureString();
        //    foreach (var c in source)
        //    {
        //        result.AppendChar(c);
        //    }
        //    return result;
        //}
    }
}