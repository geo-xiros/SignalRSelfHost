using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:9002";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.WriteLine("Press any key to close server.");
                Console.ReadKey();
                
                //var context = GlobalHost.ConnectionManager.GetHubContext<IClient>("MyHub");
                //context.Clients.All.AddMessage("hello");

                Console.ReadKey();
            }
        }
    }
    public class MyHub : Hub<IClient>, IServer
    {
        public string GetServerName()
        {
            Console.WriteLine("GetServerName Called From Client");
            return "Main Server";
        }

        public void Send(string message)
        {
            Console.WriteLine("Send Called From Client");
            Clients.All.AddMessage(message.ToUpper());
        }
    }
    public interface IServer
    {
        void Send(string message);
        string GetServerName();
    }
    public interface IClient
    {
        void AddMessage(string message);

    }
}
