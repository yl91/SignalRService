using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(SignalRService.Startup))]

namespace SignalRService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);


            app.Map("", map => {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfig = new HubConfiguration() { EnableJSONP = false };
                map.RunSignalR(hubConfig);
            });
        }
    }
}
