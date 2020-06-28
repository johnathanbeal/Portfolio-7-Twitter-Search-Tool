using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Route("api/{_username}/{_password}")]
    [ApiController]
    public class TwitterAuthController : ControllerBase
    {
        public IConfiguration ICon { get; }

        private string twitterUsername;
        private string twitterPassword;

        public TwitterAuthController(IConfiguration icon)
        {
            ICon = icon;
            twitterUsername = ICon["Twitter:Username"]; //ADD YOUR TWITTER USERNAME HERE
            twitterPassword = ICon["Twitter:Password"]; //ADD YOUR TWITTER PASSWORD HERE
        }

        public Tuple<String, String> BearerToken(string _username, string _password)
        {
            string baseURI = "https://api.twitter.com/oauth2/token";

            string grant_type = "client_credentials";

            string username = _username;

            string password = _password;

            var client = new RestClient(baseURI);
            client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest(baseURI, Method.POST);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", grant_type);
            request.AddParameter("Connection", "keep-alive");
            request.AddParameter("Accept", "application/json");
            
            IRestResponse response = client.Execute(request);

            dynamic jsonResponse = JObject.Parse(response.Content);
            String bearerToken = jsonResponse.access_token;
            String token_type = jsonResponse.token_type;
            bearerToken = bearerToken.Replace("{", "").Replace("}", "");
            token_type = token_type.Replace("{", "").Replace("}", "");

            Tuple<String, String> BearerToken = new Tuple<String, String>(token_type, bearerToken);

            return BearerToken;
        }     
    }   
}