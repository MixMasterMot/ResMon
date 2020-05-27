using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using ResourceMonHost.Signal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMonHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/library/system.net.httplistener.aspx 
            // for more information.
            //string url = "http://localhost:8080";
            string url = "http://192.168.0.110:8080";

            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);

                while (true)
                {
                    var cmd = Console.ReadLine().ToLower().Split(' ');
                    if (cmd[0] == "stop")
                    {
                        break;
                    }
                    else if (cmd[0] == "update")
                    {
                        int interval;
                        if(int.TryParse(cmd[1], out interval))
                        {
                            var context = GlobalHost.ConnectionManager.GetHubContext<InfoHub>();
                            context.Clients.All.SetUpdateInterval(interval);
                        }
                    }
                }
                Console.WriteLine("Exiting");
                
            }

        }
    }
}
