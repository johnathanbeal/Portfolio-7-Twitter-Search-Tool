using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration ICon { get; }

        private string twitterUsername;
        private string twitterPassword;

        public AuthController(IConfiguration icon)
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
            IRestResponse response = client.Execute(request);

            return "";

            //Check out Tim Corey

            //Use HttpClient

            //Or Use RestSharp
        }
    }
}