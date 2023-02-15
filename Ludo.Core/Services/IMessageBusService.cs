namespace Ludo.Core.Services
{
    public interface IMessageBusService
    {
        void Publish(string queue, byte[] messages);
    }
}
