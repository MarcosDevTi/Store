using AutoMapper;
using MediatR;
using Store.Application.ModelsCqrs.Commands;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.UoW;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Handlers
{
    public class CustomerHandlerCommands : CommandHandler,
        IRequestHandler<CustomerCreate>,
        IRequestHandler<RemoveCustomer>
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerHandlerCommands(IUnitOfWork uow, ICustomersRepository customersRepository) : base(uow)
        {
            _customersRepository = customersRepository;
        }

        public Task<Unit> Handle(CustomerCreate request, CancellationToken cancellationToken)
        {
            _customersRepository.AddAsync(Mapper.Map<Customer>(request));
            Commit();
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
