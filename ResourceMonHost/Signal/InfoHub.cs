using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ResourceMonHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMonHost.Signal
{
    [HubName("InfoHub")]
    public class InfoHub : Hub
    {
        private readonly InfoTicker _infoTicker;

        public InfoHub() : this(InfoTicker.Instance) { }

        public InfoHub(InfoTicker infoTicker)
        {
            _infoTicker = infoTicker;
        }

        public Info GetInfo()
        {
            return _infoTicker.GetInfo();
        }

        public override Task OnConnected()
        {
            Console.WriteLine("User Connected");
            return base.OnConnected();
        }
    }
}
