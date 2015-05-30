﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WebApplication.Hubs
{
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
}