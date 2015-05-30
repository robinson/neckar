using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication.Hubs;
using WebApplication.Infrastructure;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR;
using System.Net;
using Newtonsoft.Json.Linq;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Models;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public readonly static ConcurrentDictionary<string, object> State = new ConcurrentDictionary<string, object>();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Task.Factory.StartNew(() => MatchingTweetReceived(this, EventArgs.Empty));
            Task.Factory.StartNew(() => FireUpTheWork());
            //Task.Factory.StartNew(() => Stream_FilteredStreamExample());
            //Task.Factory.StartNew(()  => new TwitterConnection());
            //Hieu: add service bus here
            //GlobalHost.DependencyResolver.UseServiceBus("", "Chat"); 
        }
        private void FireUpTheWork()
        {

            //TODO: No exception handling so far. Handle it better.
            //TODO: Don't block as much as possible and don't use Result

            var globalStreamGroupName = "Global";

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            State["cts"] = cancellationTokenSource;

            var isCycleOn = true;

            using (TwitterConnector twitterConnector = new TwitterConnector())
            {

                //TODO: Response message might be other than 200
                //      if this is the case, the other parts of the code might not work
                //      as excpected. Handle this.
                var response = twitterConnector.GetLocationBasedConnection("-165.0,-75.0,165.0,75.0").Result;
                //var response = twitterConnector.GetSampleFirehoseConnection().Result;
                var contentResult = response.Content.ReadAsStreamAsync().Result;

                using (var streamReader = new StreamReader(contentResult, Encoding.UTF8))
                {

                    var clients = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>().Clients;

                    var cts = (CancellationTokenSource)State["cts"];
                    while (!streamReader.EndOfStream && !cts.IsCancellationRequested)
                    {

                        var result = streamReader.ReadLine();
                        if (!string.IsNullOrEmpty(result))
                        {

                            //TODO: Handle the exceptions here.
                            var tweetJToken = JsonConvert.DeserializeObject<dynamic>(result);
                            var tweetObj = tweetJToken["text"];
                            //var arrTweetHashTags = tweetJToken["entities"]["hashtags"];
                            //StringBuilder builder = new StringBuilder();                            
                            //foreach (JObject o in arrTweetHashTags.Children<JObject>())
                            //{
                            //    foreach (JProperty p in o.Properties())
                            //    {
                            //        if (p.Name == "text")
                            //        {
                            //            builder.Append(p.Value);
                            //            builder.Append(',');
                            //        }
                                    
                            //    }
                            //}
                            //string tweetHashTag = builder.ToString();

                            if (tweetObj != null)//Hieu
                            {
                                var tweetText = tweetObj.ToString();

                                var userScreenName = tweetJToken["user"]["screen_name"].ToString();
                                var imageUrl = tweetJToken["user"]["profile_image_url_https"].ToString();

                                var tweet = new WebApplication.Entities.Model.Tweet() { TweetText = tweetText, User = userScreenName, ImageUrl = imageUrl };

                                var coordinatesRoot = tweetJToken["coordinates"];

                                if (coordinatesRoot != null && !string.IsNullOrEmpty(coordinatesRoot.ToString()))
                                {

                                    var coordinates = coordinatesRoot["coordinates"];
                                    tweet.Longitude = coordinates[0];
                                    tweet.Latitude = coordinates[1];
                                }

                                //broadcast tweet to global stream subscribers
                                clients.Group(globalStreamGroupName).broadcastTweet(tweet);

                                //Hieu: post to the client of Orleans
                                //PostTweetToClient(tweetText, tweetHashTag);
                                //http://localhost:5190/" + hashtags + "/" + score
                                //WebRequest request = WebRequest.Create("http://www.contoso.com/");
                            }
                        }
                    }
                    if (cts.IsCancellationRequested)
                    {
                        isCycleOn = false;
                    }
                }
            }

            if (isCycleOn)
            {
                FireUpTheWork();
            }
        }
        private void PostTweetToClient(string tweetText, string tweetHashTag)
        {
            var sentiment = Sentiment.Instance;
            var score = sentiment.GetScore(tweetText);
            WebRequest request = WebRequest.Create("http://localhost:5190/" + tweetHashTag + "//" + score.Sentiment);
            request.Method = "POST";
        }
    }
}
