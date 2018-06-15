using MediatR;
using Store.Application.ModelsCqrs.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Handlers
{
    public class CustomerEventHandler :
        INotificationHandler<CustomerRegisteredEvent>
    {
        public Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }
    }
}
