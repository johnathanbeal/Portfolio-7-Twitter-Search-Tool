let uri = "https://localhost:44361/api/tweets/lincoln";
let url = "api/tweets/";

async function TryFetch(search) {
    const data;
    url = url + search;
    console.log("start");
    try {
        fetch(url).then(r => r.json());

        data = await fetch(url)
            .then(response => response.json())
            .then(data => console.log(data));

        //let response = await fetch(uri);
        //console.log("call to fetch api with full url");
        //if (response.ok) { // if HTTP-status is 200-299
        //    // get the response body (the method explained below)
        //    let json = await response.json();
        //    console.log(json);
        //    alert("Response is " + json);
        //} else {
        //    alert("HTTP-Error: " + response.status);
        //}
        console.log("complete try block");
    }
    catch
    {
        let response = await fetch(url);

        console.log("call to fetch api with relative url");
        if (response.ok) { // if HTTP-status is 200-299
            // get the response body (the method explained below)
            let json = await response.json();
            console.log(json);
            alert("Response is " + json);
        } else {
            alert("HTTP-Error: " + response.status);
        }
        console.log("complete catch block");
    }
    console.log("finish");
    return data;
}
