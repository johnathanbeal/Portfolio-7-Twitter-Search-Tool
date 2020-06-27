let uri = "https://localhost:44361/api/tweets/lincoln"

async function TryFetch() {
    let response = await fetch(uri);

    if (response.ok) { // if HTTP-status is 200-299
        // get the response body (the method explained below)
        let json = await response.json();
        console.log(json);
        alert("Response is " + json);
    } else {
        alert("HTTP-Error: " + response.status);
    }
}
