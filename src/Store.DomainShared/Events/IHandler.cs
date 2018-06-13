namespace Store.DomainShared.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
