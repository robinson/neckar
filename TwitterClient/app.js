var twitter = require('twitter');
var sentiment = require('sentiment');
var http = require('http');
var url = require('url');

// please update the client with your own twitter credentials.
// https://dev.twitter.com/

var twit = new twitter({
    consumer_key: 'tkr9B1TdVpsPgrgDoM0XPmdYP',
    consumer_secret: '2Rl5ukIAj9prHCBg1CSeCGex1qXSnJYkgOVX1WTEwb2HKaMHgW',
    access_token_key: '49227431-K8J2y8saXX04UeYtCnbPc1fyY9iKG4kVfjK3odVB0',
    access_token_secret: '35Ks5f3P4eclgtdNhodyjdLP0UEt0FEkEeL1Yhr42mZnp'
});

twit.stream('filter', {locations:'-180,-90,180,90'}, function(stream) {
    stream.on('data', function(data) {

    	if (!data.text) return;
		console.log(data.text); 

		sentiment(data.text, function (err, result) {
            var hashtags = data.entities.hashtags.map(function(x){return x.text}).join(',');
            if (hashtags == ""){
                hashtags = "none";
            }
            post(hashtags, result.score, data.text);

		});
    });
});

function post(hashtags, score, tweet, cb){
    
    var options = url.parse("http://localhost:5190/" + hashtags + "/" + score);
    options.method = 'POST';
    var req = http.request(options, function(res) {
        res.on('data', function() { /* do nothing */ });
    });
 
    req.on('error', function(e) {
      console.log('error: ' + e.message);
    });

    req.write(tweet);
    req.end();    
}