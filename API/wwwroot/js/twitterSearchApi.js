let uri = "https://api.twitter.com/1.1/search/tweets.json"
let username = "user";
let password = "passwd";

function getTweets() {
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
    let base64 = require('base-64');

    let url = "https://api.twitter.com/oauth2/token";
    username = TwitterUsername();
    password = TwitterPassword();

    let headers = new Headers();

    headers.append('Authorization', 'Basic ' + base64.encode(username + ":" + password));

}

function TwitterUsername() {
    var authInfo = "<%= TwitterTokenAuthInfo %>";
    return authInfo.TwitterUsername 
}

function TwitterPassword() {
    var authInfo = "<%= TwitterTokenAuthInfo %>";
    return authInfo.TwitterPassword;
}