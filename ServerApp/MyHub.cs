using Microsoft.AspNet.SignalR;
using System;

namespace ServerApp
{
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
}
