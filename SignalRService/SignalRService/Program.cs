using Easy.Public;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRService
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = IpHelper.LoopbackIp();
            int port = GetPort(ip);
            string baseUrl = string.Format("http://{0}:{1}/", ip, port);
            System.Console.WriteLine(baseUrl);
            using (WebApp.Start<Startup>(new StartOptions(baseUrl)))
            {
                System.Console.WriteLine("服务启动中...");
                while (true)
                {
                    Thread.Sleep(80000012);
                }
            }
        }

        private static int GetPort(string ip)
        {
            string portfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "port.txt");

            if (File.Exists(portfile))
            {
                return int.Parse(File.ReadAllText(portfile));
            }

            int port = Easy.Public.IpHelper.GetAvailablePort(ip, 8000, 9999);

            File.WriteAllText(portfile, port.ToString());
            return port;
        }
    }
}
