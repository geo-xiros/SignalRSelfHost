namespace ServerApp
{
    public interface IServer
    {
        void Send(string message);
        string GetServerName();
    }
}
