let uri = "https://api.twitter.com/1.1/search/tweets.json"

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