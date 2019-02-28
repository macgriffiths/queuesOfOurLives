namespace Common.Services.Contracts
{
    public interface IConnectionService
    {
        bool PublishMessage(string message, string queque);
        void ReceiveMessage(string queue);
    }
}
