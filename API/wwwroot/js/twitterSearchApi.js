let uri = "https://api.twitter.com/1.1/search/tweets.json"
let username = "user";
let password = "passwd";

function getTweets() {

    var token = getToken();

    uri = uri + "?" + getSearchText();
    fetch(uri)
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            console.log(data);
        })
        .catch(function (err) {
            console.log("Something went wrong!", err);
        })
}

//function getSearchParameter() {
//    return document.getElementById("submit").addEventListener("click", getSearchText);
//}

function getSearchText() {
    console.log("test");
    console.log(document.getElementById("search").textContent);
    console.log(document.getElementById("search").innerText);
    console.log(document.getElementById("search"));
    return document.getElementById("search").value;
}

function basicAuth() {
    try {
        let base64 = require('base-64');
        console.log(base64);

        let url = "https://api.twitter.com/oauth2/token";
        console.log(url);
        username = TwitterUsername();
        console.log(username);
        password = TwitterPassword();
        console.log(password());

        let headers = new Headers();

        headers.set('Authorization', 'Basic ' + base64.encode(username + ":" + password));

        fetch(url, {
            method: 'GET',
            headers: headers,
        })
            .then(response => response.json())
            .then(json => console.log(json));

        function parseJSON(response) {
            return response.json()
        }
    }
    catch (error)
    {
        console.error(error);
        console.log(error);
    }
    

    //https://stackoverflow.com/questions/43842793/basic-authentication-with-fetch
}

function TwitterUsername() {
    try {
        var secret = require("..\secrets.json");
    }
    catch (error)
    {
        console.error(error);
        console.log(error);
    }
    console.log(secret.Twitter.Username);
    //var authInfo = "<%= TwitterTokenAuthInfo %>";
    //var twitterUsername = Configuration["Twitter:Username"];
    return twitterUsername 
}

function TwitterPassword() {
    //var authInfo = "<%= TwitterTokenAuthInfo %>";
    var secret = require("..\secrets.json");

    console.log(secret.Twitter.Password);
    //var twitterPassword = Configuration["Twitter:Password"];
    return twitterPassword;
}

function getToken() {
    let url = "https://api.twitter.com/oauth2/token";
    let username = TwitterUsername();
    let password = TwitterPassword();

    let headers = {
        'Authorization': 'Basic ' + base64.encode(username + ":" + password)
    };

    let options = {
        method: 'POST',
        headers: headers
    }
    fetch(url, options)
        .then((httpResponse) => {
            console.log(httpResponse.json);
            console.log(httpResponse.text);
            return httpResponse.json;
        });
}