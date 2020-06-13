using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

            return "";
        }
    }
}