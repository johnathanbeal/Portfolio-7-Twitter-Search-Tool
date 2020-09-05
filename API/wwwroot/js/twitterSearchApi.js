
async function TryFetch(search) {
    let url = "api/tweets/";

    let displayTweets = document.querySelector("#display-tweet-text");
    //let displayScreenName = document.querySelector("#display-screen-name");

    url = url + search.replace(" ","%20");
    console.log("start");
    try {      
            await fetch(url)
                .then(function (response) {
                    return response.json();
                })
                .then(function (result) {
                let output =
                        "<table><thead><tr><th>Tweets</th><thead><tbody>";
                    var ordinal = 1;
                    for (let i in result.statuses) {

                        output +=  
                            "<tr><td><img src=result.statuses[i].entities.media[0].media_url></img >" +
                            "<div style=\"color: blue\">" + ordinal + ": Screen Name: " + result.statuses[i].user.screen_name + "</div>" +
                            "<div>From " + result.statuses[i].user.location + "</div>" +
                            "<div style=\"color: orange\"> Name: " + result.statuses[i].user.name +
                            "</div><div><p style=\"color: green\"> Tweeted ~" + result.statuses[i].text +
                            "</div></td></tr>";

                        ordinal++;
                }
                output += "</tbody></table>";
                displayTweets.innerHTML = output;
            });          
        console.log("complete try block");
    }
    catch
    {
        let response = await fetch(url);

        console.log("call to fetch api with relative url");
        if (response.ok) { 
            let json = await response.json();
            console.log(json);
            alert("Response is " + json);
        } else {
            alert("HTTP-Error: " + response.status);
        }
        console.log("complete catch block");
    }
    console.log("finish");
    return true;
}
