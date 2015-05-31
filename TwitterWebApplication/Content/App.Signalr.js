$(function () {
    $.connection.hub.url = "http://localhost:8181/signalr";//hieu: update signalR url
    // Declare a proxy to reference the hub.
    var twitterHub = $.connection.twitterHub,
        $startBtn = $("#startBtn"),
        $stopBtn = $("#stopBtn"),
        map;

    toastr.options.fadeOut = 1000;
    toastr.options.timeOut = 1500;
    //toastr.options.positionClass = "toast-top-center";

    function calculateToastrPosition() {

        var windowWidth = $(window).width(),
            toastMsgWidth = 300;

        var leftOffset = (windowWidth - toastMsgWidth) / 2;
        $('<style>').text(".toast-top-center { top: 10px; left: " + leftOffset + "px; }").appendTo("head");
    }

    function initialize() {

        var mapOptions = {
            zoom: 2,
            center: new google.maps.LatLng(34.397, -10.644),
            mapTypeId: google.maps.MapTypeId.HYBRID
        };
        map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    }

    function subscribeGlobalStream() {

        twitterHub.server.subscribeToStreamGroup("Global").done(function (result) {

            toastr.success("Successfully subscribed to Global Twitter stream.");
            if (result === true) {

                $startBtn.prop("disabled", true);
                $stopBtn.prop("disabled", false);
            }
        });
    }

    function unsubscribeGlobalStream() {

        twitterHub.server.unsubscribeFromStreamGroup("Global").done(function () {

            toastr.success("Successfully unsubscribed from Global Twitter stream.");
            $stopBtn.prop("disabled", true);
            $startBtn.prop("disabled", false);
        });
    }

    function buildInitialInfoWindowContent(tweet) {

        var infoWindowContent = '<img style="height:40px;margin-right:10px;" src="' + tweet.ImageUrl + '" />'
        infoWindowContent += '<span style="color: green;">Tweet by <strong>@@';
        infoWindowContent += tweet.User + '</strong>:</span> ' + tweet.TweetTextHtml;

        return infoWindowContent;
    }

    function setInfoWindowContent(iw) {

        //do the useful stuff here and alter the content
        //iw.setContent(iw.content + "foo");
    }

    initialize();

    calculateToastrPosition();

    twitterHub.client.broadcastTweet = function (tweet) {
        $("#messages").prepend(
            $("<li>").html('<span style="color: green;">Tweet by <strong>@@' + tweet.User + '</strong>:</span> ' + tweet.TweetTextHtml)
        );

        if (tweet.Longitude) {

            var marker = new google.maps.Marker({
                animation: google.maps.Animation.DROP,
                position: new google.maps.LatLng(tweet.Latitude, tweet.Longitude),
                title: tweet.TweetText + " by @@" + tweet.User
            });

            var infowindow = new google.maps.InfoWindow({
                content: buildInitialInfoWindowContent(tweet)
            });

            marker.setMap(map);

            google.maps.event.addListener(marker, "click", function () {

                if (infowindow.isContentSet !== true) {

                    infowindow.isContentSet = true;
                    setInfoWindowContent(infowindow);
                }

                infowindow.open(map, marker);
            });

            google.maps.event.addListener(infowindow, "domready", function () {

                var _infoWindow = this;
            });
        }
    }

    $.connection.hub.start().done(function () {

        subscribeGlobalStream();

        $stopBtn.click(function (e) {

            unsubscribeGlobalStream();
            e.preventDefault();
        });

        $startBtn.click(function (e) {

            subscribeGlobalStream();
            e.preventDefault();
        });
    });
});
