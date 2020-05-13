$(function () {
    //Set the hubs URL for the connection "http://localhost:8080/signalr"
    $.connection.hub.url = "http://localhost:8080/signalr";

    // Declare a proxy to reference the hub.
    var ticker = $.connection.InfoHub;

    
    // init function
    function init() {
        console.log("init");
    }

    ticker.client.updateInfo = function (info) {
        console.log(info);
    }
    // Start the connection.
    $.connection.hub.start().done(init);
});