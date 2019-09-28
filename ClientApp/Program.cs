using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using ServerApp;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:9002");
            IHubProxy proxy = hubConnection.CreateHubProxy("MyHub");
            proxy.On<string>(nameof(IClient.AddMessage), (m) => Console.WriteLine($"Data from server {m}"));
            hubConnection.Start().Wait();

            proxy.Invoke(nameof(IServer.Send), "george");

            var result = proxy.Invoke<string>(nameof(IServer.GetServerName));

            result.ContinueWith((t) =>
            {
                Console.WriteLine($"Server name is {t.Result}");
            });


            Console.WriteLine("Press any key to close client.");
            Console.ReadKey();

        }
    }
}
