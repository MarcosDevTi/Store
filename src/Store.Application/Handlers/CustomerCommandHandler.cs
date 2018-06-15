using AutoMapper;
using MediatR;
using Store.Application.ModelsCqrs.Commands;
using Store.Application.ModelsCqrs.Events;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.UoW;
using Store.DomainShared.Bus;
using Store.DomainShared.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Handlers
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomer>,
        IRequestHandler<RemoveCustomer>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMediatorHandler _bus;

        public CustomerCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, ICustomersRepository customersRepository) : base(uow, bus, notifications)
        {
            _customersRepository = customersRepository;
            _bus = bus;
        }

        public Task<Unit> Handle(RegisterNewCustomer message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Unit.Task;
            }

            var customer = Mapper.Map<Customer>(message);

            //if (_customersRepository.GetByEmailAsync(message.AddressEmail) != null)
            //{
            //    _bus.RaiseEvent(new DomainNotification(message.MessageType, "The customer e-mail has already been taken."));
            //    return Unit.Task;
            //}

            _customersRepository.AddAsync(customer);

            if (Commit())
            {
                _bus.RaiseEvent(new CustomerRegisteredEvent(customer.Id, customer.Name.ToString(), customer.Email.ToString(), customer.BirthDate));
            }

            return Unit.Task;

        }

        public Task<Unit> Handle(RemoveCustomer request, CancellationToken cancellationToken)
        {
            _customersRepository.RemoveAsync(request.Id);
            Commit();
            return Unit.Task;
        }
    }
}
