using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRService
{
    [HubName("pushHub")]
    public class LogHub:Hub
    {
        public override Task OnConnected()
        {
            var c = this.Clients;
            c.All.notice("大家注意有人来了");
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("有个人重连了");
            return base.OnReconnected();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            var c = this.Clients.Caller;
            this.Clients.All.notice("有人断开了 ,他是" + this.Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}
