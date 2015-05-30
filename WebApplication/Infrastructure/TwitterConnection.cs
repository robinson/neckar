using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Tweetinvi;
using WebApplication.Hubs;

namespace WebApplication.Infrastructure
{
    public class TwitterConnection
    {
        private string _consumerKey = ConfigurationManager.AppSettings.Get("consumerKey");
        private string _consumerSecret = ConfigurationManager.AppSettings.Get("consumerSecret");
        private string _accessKey = ConfigurationManager.AppSettings.Get("accessToken");
        private string _accessToken = ConfigurationManager.AppSettings.Get("accessTokenSecret");

        public TwitterConnection()
        {
            TwitterCredentials.SetCredentials(_accessKey, _accessToken, _consumerKey, _consumerSecret);
            // Access the filtered stream
            var filteredStream = Stream.CreateFilteredStream();
            var clients = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>().Clients;
            var globalStreamGroupName = "Global";
            var stream = Tweetinvi.Stream.CreateFilteredStream();
            var location = Geo.GenerateLocation(-165.0, -75.0, 165.0, 75.0);

            stream.AddLocation(location);

            filteredStream.MatchingTweetReceived += (sender, args) =>
            {
                var tweet = args.Tweet;
                if (tweet != null)
                {
                    var tweetText = tweet.Text;
                    var userScreenName = tweet.Creator.ScreenName;// tweetJToken["user"]["screen_name"].ToString();
                    var imageUrl = tweet.Creator.ProfileImageUrlHttps;//tweetJToken["user"]["profile_image_url_https"].ToString();
                    var tweetModel = new WebApplication.Entities.Model.Tweet() { TweetText = tweetText, User = userScreenName, ImageUrl = imageUrl };

                    if (tweet.Coordinates != null)
                    {
                        tweetModel.Longitude = tweet.Coordinates.Longitude.ToString();
                        tweetModel.Latitude = tweet.Coordinates.Latitude.ToString();
                    }

                    //broadcast tweet to global stream subscribers
                    clients.Group(globalStreamGroupName).broadcastTweet(tweetModel);

                    //Hieu: post to the client of Orleans
                    string strTweetHashTag = string.Empty;
                    if (tweet.Hashtags != null)
                    {
                        foreach (var tag in tweet.Hashtags)
                        {
                            strTweetHashTag += tag.Text + ",";
                        }
                    }
                }
            };

            filteredStream.StartStreamMatchingAllConditions();
        }
    }
}