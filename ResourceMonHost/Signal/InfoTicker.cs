using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ResourceMonHost.Models;

namespace ResourceMonHost.Signal
{
    public class InfoTicker:Monitor.Monitor
    {
        private readonly static Lazy<InfoTicker> _instance = new Lazy<InfoTicker>(() => new InfoTicker(GlobalHost.ConnectionManager.GetHubContext<InfoHub>().Clients));

        public IHubConnectionContext<dynamic> Clients { get; set; }

        private readonly Info _info = new Info();

        private readonly object _updateInfo = new object();

        // readonly
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(1000);
        // readonly
        private readonly Timer _timer;
        private volatile bool _updateingInfo = false;

        private InfoTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;

            _info = new Info();

            _timer = new Timer(UpdateInfo,null,_updateInterval,_updateInterval);
        }

        public static InfoTicker Instance
        {
            get { return _instance.Value; }
        }

        private void UpdateInfo(object state)
        {
            lock (_updateInfo)
            {
                if(!_updateingInfo)
                {
                    _updateingInfo = true;

                    BroadcastInfo(GetSystemInfo());
                    
                    _updateingInfo = false;
                }
            }
        }

        private void BroadcastInfo(Info info)
        {
            Clients.All.updateInfo(info);
        }

        public Info GetInfo()
        {
            return _info;
        }
        
    }
}
