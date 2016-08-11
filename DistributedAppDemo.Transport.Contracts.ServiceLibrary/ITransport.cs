namespace DistributedAppDemo.Transport.Contracts.ServiceLibrary
{
    public interface ITransport
    {
        void Send<T>(T payload);
    }
}