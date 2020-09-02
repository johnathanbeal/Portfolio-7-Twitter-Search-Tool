using Domain.BearerToken;
using Domain.Interface;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Domain.Integration
{
    public class TwitterService : ITwitterService
    {
        private string _twitterUsername;
        private string _twitterPassword;
        public TwitterService(IConfiguration configuration)
        {
            _twitterUsername = configuration["Twitter:Username"]; //ADD YOUR TWITTER USERNAME HERE
            _twitterPassword = configuration["Twitter:Password"]; //ADD YOUR TWITTER PASSWORD HERE
        }

        public string GetBearerToken()
        {
            var baseUri = "https://api.twitter.com/oauth2/token";

            var client = new RestClient(baseUri);

            var grantType = "client_credentials";


            client.Authenticator = new HttpBasicAuthenticator(_twitterUsername, _twitterPassword);

            var request = new RestRequest(baseUri, Method.POST);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", grantType);
            request.AddParameter("Connection", "keep-alive");
            request.AddParameter("Accept", "application/json");

            var response = client.Execute<TwitterBearerToken>(request);

            return response.Data.AccessToken;
        }
    }
}
