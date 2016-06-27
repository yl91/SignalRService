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
            var username = this.Context.QueryString["username"];
            var groupName= this.Context.QueryString["groupname"];
            JoinGroup(groupName);
            Clients.Group(groupName).addMessage(1,$"有人重连了,username:{username}");
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            var username = this.Context.QueryString["username"];
            string groupName = this.Context.QueryString["groupname"];
            LeaveGroup(groupName);
            JoinGroup(groupName);
            Clients.Group(groupName).addMessage(2,$"有人重连了,username:{username}");
            return base.OnReconnected();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            var username = this.Context.QueryString["username"];
            string groupName = this.Context.QueryString["groupname"];
            LeaveGroup(groupName);
            Clients.Group(groupName).addMessage(3,$"有人断开连接了,username:{username}");
            return base.OnDisconnected(stopCalled);
        }
        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }

    }
}
