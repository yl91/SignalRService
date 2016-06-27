using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SignalRService.Controller
{
    public class PushController: ApiController
    {
        [HttpGet]
        public string Test(string serviceName,string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return "no";
            }
            IHubContext chat = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
            chat.Clients.Group(serviceName).notice(msg);


            return "ok";
        }
    }
}
