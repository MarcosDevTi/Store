using Store.DomainShared.Cqrs.Commands;
using Store.DomainShared.Events;
using System.Threading.Tasks;

namespace Store.DomainShared.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
