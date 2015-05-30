using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Enum;
using Tweetinvi.Core.Interfaces.Models;
using Tweetinvi.Core.Interfaces.Models.Parameters;
using System.Configuration;

namespace TwitterStreamingService
{
    class Program
    {
        static void Main(string[] args)
        {
            TwitterCredentials.SetCredentials(
               ConfigurationManager.AppSettings["token_AccessToken"],
               ConfigurationManager.AppSettings["token_AccessTokenSecret"],
               ConfigurationManager.AppSettings["token_ConsumerKey"],
               ConfigurationManager.AppSettings["token_ConsumerSecret"]);

        }
        private static void Stream_FilteredStreamExample()
        {
            for (; ; )
            {
                try
                {
                    var stream = Stream.CreateSampleStream();
                    stream.FilterTweetsToBeIn(Language.English);//Hieu
                    stream.TweetReceived += (sender, args) =>
                    {
                        var tweet = args.Tweet;
                        //hbase.WriteTweet(tweet);Hieu
                        if (tweet.Coordinates != null)
                        {
                            Console.WriteLine("{0}: {1}", tweet.Id, tweet.Text);
                            Console.WriteLine("\tLocation: {0}, {1}", tweet.Coordinates.Longitude, tweet.Coordinates.Latitude);
                        }
                        else
                        {
                            //Console.WriteLine("\tLocation: null");
                        }
                        if (tweet.Place != null)
                        {
                            Console.WriteLine("\tPlace: {0}", tweet.Place.FullName);
                        }

                        /*IEnumerable<ILocation> matchingLocations = args.Tweet.;
                        foreach (var matchingLocation in matchingLocations)
                        {
                            Console.Write("({0}, {1}) ;", matchingLocation.Coordinate1.Latitude, matchingLocation.Coordinate1.Longitude);
                            Console.WriteLine("({0}, {1})", matchingLocation.Coordinate2.Latitude, matchingLocation.Coordinate2.Longitude);
                        }*/
                    };

                    //stream.StartStreamMatchingAllConditions();
                    stream.StartStream();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                }
            }
        }
        private static void Search_FilteredSearch()
        {
            var stream = Stream.CreateFilteredStream();
            var location = Geo.GenerateLocation(-124.75, 36.8, -126.89, 32.75);

            stream.AddLocation(location);
            stream.AddTrack("tweetinvi");
            stream.AddTrack("linvi");

            stream.MatchingTweetAndLocationReceived += (sender, args) =>
            {
                var tweet = args.Tweet;
                Console.WriteLine("{0} was detected between the following tracked locations:", tweet.Id);

                IEnumerable<ILocation> matchingLocations = args.MatchedLocations;
                foreach (var matchingLocation in matchingLocations)
                {
                    Console.Write("({0}, {1}) ;", matchingLocation.Coordinate1.Latitude, matchingLocation.Coordinate1.Longitude);
                    Console.WriteLine("({0}, {1})", matchingLocation.Coordinate2.Latitude, matchingLocation.Coordinate2.Longitude);
                }
            };

            stream.StartStreamMatchingAllConditions();
        }

        private static void Stream_SampleStreamExample()
        {
            var stream = Stream.CreateSampleStream();

            stream.TweetReceived += (sender, args) =>
            {
                Console.WriteLine(args.Tweet.Text);
            };

            //stream.AddTweetLanguageFilter(Language.English);
            //stream.AddTweetLanguageFilter(Language.French);

            stream.StartStream();
        }
    }
}
