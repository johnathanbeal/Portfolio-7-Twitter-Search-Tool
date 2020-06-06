let uri = "https://api.twitter.com/1.1/search/tweets.json?george+floyd"

function getTweets() {
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