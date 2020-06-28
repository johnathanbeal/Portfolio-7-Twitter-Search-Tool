
async function TryFetch(search) {
    let url = "api/tweets/";

    let displayTweets = document.querySelector("#display-tweets");

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
                        "<tr><td>" +
                        ordinal + ": " + result.statuses[i].text +
                            "</td></tr>";
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
