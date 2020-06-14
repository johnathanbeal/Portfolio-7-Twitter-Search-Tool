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
using System.Reflection.Metadata;
using System.Web;
using RestSharp.Serialization.Json;
using Newtonsoft.Json.Linq;

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

        public String BearerToken(string _username, string _password)
        {
            //Resource URL
            string baseURI = "https://api.twitter.com/oauth2/token";

            //Resource info > //Response Format

            //>Requires Authentication

            //>Rate Limited

            //Parameters>//Grant Type = client_credentials

            string grant_type = "client_credentials";

            //Authorization
            //declare key/username
            string username = _username;

            //declare secret/password
            string password = _password;

            var client = new RestClient(baseURI);
            client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest(baseURI, Method.POST);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", grant_type);
            request.AddParameter("Connection", "keep-alive");
            request.AddParameter("Accept", "application/json");
            
            IRestResponse response = client.Execute(request);

            var statusCode = response.StatusCode;
            var debug = response.ResponseStatus;
            var debug2 = response.Content;
            dynamic jsonResponse = JObject.Parse(response.Content);
            var bearerToken = jsonResponse.access_token;
            var token_type = jsonResponse.token_type;
                


            return bearerToken;
        }

        public async Task<String> WastedTime(string _username, string _password)
        {
            //URI
            string baseURI = "https://api.twitter.com/oauth2/token";
            //Authorization
            //declare key/username
            string username = _username;

            //declare secret/password
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
            //request.AddParameter("Authorization", "Basic bklVSzA5ZUg1TUYyQTJhQ2RxbWhoNEl1bjpTSFpaUmx0cHgyc2xYQUN1T0E1Qng1NGxpRmRZVVEwYlVSeGVuRU5GVFZmOXI5Z00yVw==");

            //Set JSON as Response Type
            //request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("grant_type", "client_credentials");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            IRestResponse response = client.Execute(request);//multiple attempts with varied headers and parameters return code 99, even after logging out of Twitter
            
            //How Tim Pool makes this work
            //using a mix of types, not just RestSharp

            //declare key/username
            //string username = _username;

            //declare secret/password
            //string password = _password;

            //concatenate key and secret with a ':' in between
            var twitterCredentials = username + ":" + password;

            //Convert to Base 64
            var base64Creds = Convert.ToBase64String(Encoding.UTF8.GetBytes(twitterCredentials));

            // ?? ServicePointManager

            // create URI
            var requestURI = new Uri(baseURI);

            // create request
            RestRequest restRequest = new RestRequest(baseURI, Method.POST);

            // Add authorization header
            restRequest.AddHeader("Authorization", $"Basic {base64Creds}");

            /// My Line Add Grant Type
            request.AddParameter("grant_type", "client_credentials");

            //request.AddJsonBody(new PrimitiveType<String>() { "grant_type" : "client_credentials" });


            // set protocol version
            //?

            // set timeout
            restRequest.Timeout = 5000;

            // set max idle time

            // set connection limit

            // set content type

            // keep alive

            // set rest method

            // set Accept

            // fancy code for setting grant_type

            // set decompression
            restRequest.AddDecompressionMethod(DecompressionMethods.None);



            // set cookie container


            // return request
            IRestResponse response2 = client.Execute(request);
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
        

    public void GetRequestToken(string _username, string _password, string _callbackUrl)
    {
        string callBackUrl = _callbackUrl;

        var client = new RestClient("https://api.twitter.com/oauth2/token");
        //declare key/username
        string username = _username;

        //declare secret/password
        string password = _password;
        client.Authenticator = OAuth1Authenticator.ForRequestToken(
            username,
            password,
            callBackUrl
            );

            var request = new RestRequest("/oauth2/token", Method.POST);
            var response = client.Execute(request);

            var queryString = HttpUtility.ParseQueryString(response.Content);

            string oauthToken = queryString["oauth_token"];
            string oauthTokenSecret = queryString["oauth_token_secret"];

            string accessToken = queryString["access_token"];

            request = new RestRequest("oauth/authorize?oauth_token=" + oauthToken);

    }
}

    
}