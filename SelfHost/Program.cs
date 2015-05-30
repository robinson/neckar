using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces.Models;

namespace SelfHost
{
    class Program
    {
        private static string _consumerKey = ConfigurationManager.AppSettings.Get("consumer_key");
        private static string _consumerSecret = ConfigurationManager.AppSettings.Get("consumer_secret");
        private static string _accessKey = ConfigurationManager.AppSettings.Get("access_token_key");
        private static string _accessToken = ConfigurationManager.AppSettings.Get("access_token_secret");
        static void Main(string[] args)
        {
            string url = "http://localhost:8181";
            using (WebApp.Start(url))
            {
                //Console.WriteLine("Server running on {0}", url);
                TwitterCredentials.SetCredentials(_accessKey, _accessToken, _consumerKey, _consumerSecret);
                Stream_FilteredStreamExample();
                //Stream_SampleStreamExample();
            }
        }
        private static void Stream_SampleStreamExample()
        {
            for (; ; )
            {
                var stream = Stream.CreateSampleStream();

                stream.TweetReceived += (sender, args) =>
                {
                    Console.WriteLine(args.Tweet.Text);
                };

                stream.AddTweetLanguageFilter(Language.English);
                stream.AddTweetLanguageFilter(Language.French);

                stream.StartStream();
            }
        }

        private static void Stream_FilteredStreamExample()
        {
            for (; ; )
            {
                try
                {
                    var clients = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>().Clients;
                    var globalStreamGroupName = "Global";

                    var stream = Stream.CreateFilteredStream();
                    stream.AddLocation(Geo.GenerateLocation(-180, -90, 180, 90));
                    var tweetCount = 0;
                    var timer = Stopwatch.StartNew();

                    stream.MatchingTweetReceived += (sender, args) =>
                    {
                        tweetCount++;
                        var tweet = args.Tweet;
                        if (timer.ElapsedMilliseconds > 1000)
                        {
                            if (tweet.Coordinates != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n{0}: {1} {2}", tweet.Id, tweet.Language.ToString(), tweet.Text);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\tLocation: {0}, {1}", tweet.Coordinates.Longitude, tweet.Coordinates.Latitude);
                            }

                            timer.Restart();
                            Console.WriteLine("\tTweets/sec: {0}", tweetCount);
                            tweetCount = 0;
                        }

                        var tweetText = tweet.Text;
                        var userScreenName = tweet.Creator.ScreenName;// tweetJToken["user"]["screen_name"].ToString();
                        var imageUrl = tweet.Creator.ProfileImageUrlHttps;//tweetJToken["user"]["profile_image_url_https"].ToString();
                        var tweetModel = new Tweet() { TweetText = tweetText, User = userScreenName, ImageUrl = imageUrl };

                        if (tweet.Coordinates != null)
                        {
                            tweetModel.Longitude = tweet.Coordinates.Longitude.ToString();
                            tweetModel.Latitude = tweet.Coordinates.Latitude.ToString();
                        }

                        ////broadcast tweet to global stream subscribers
                        clients.Group(globalStreamGroupName).broadcastTweet(tweetModel);

                    };

                    stream.StartStreamMatchingAllConditions();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);

                }
            }

        }
    }

    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class TwitterHub : Hub
    {
        private static string[] _reservervedGroupNames = new[] { "Global" };

        public void CancelStream()
        {

            //var cts = Global.State["cts"] as CancellationTokenSource;
            //if (cts != null) {

            //    cts.Cancel();
            //}
        }

        public bool SubscribeToStreamGroup(string groupName)
        {

            if (_reservervedGroupNames.Any(x => x.Equals(groupName, StringComparison.OrdinalIgnoreCase)))
            {
                Groups.Add(Context.ConnectionId, groupName);
                return true;
            }
            return false;
        }

        public void UnsubscribeFromStreamGroup(string groupName)
        {

            if (_reservervedGroupNames.Any(x => x.Equals(groupName, StringComparison.OrdinalIgnoreCase)))
            {
                Groups.Remove(Context.ConnectionId, groupName);
            }
        }
    }
    public class Tweet
    {

        public string User { get; set; }
        public string TweetText { get; set; }
        public string CreatedAt { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public double AverageSentimentTokens { get; set; }
        public string TweetTextHtml
        {

            get
            {

                return (!string.IsNullOrEmpty(TweetText)) ?
                    TweetText.ParseURL().ParseHashtag().ParseUsername() :
                    TweetText;
            }
        }
    }
}
