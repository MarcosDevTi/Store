using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Store.Application.ModelsCqrs;
using Store.Domain.Repositories;

namespace Store.Application.Handlers
{
    public class CustomerHandler :
        IRequestHandler<GetAllCustomers, IReadOnlyList<CustomerViewModel>>,
        IRequestHandler<GetCustomerById, CustomerViewModel>
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public async Task<IReadOnlyList<CustomerViewModel>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
        {
            return await Mapper.Map<Task<IReadOnlyList<CustomerViewModel>>>(_customersRepository.GetAllAsync());
        }

        public async Task<CustomerViewModel> Handle(GetCustomerById request, CancellationToken cancellationToken)
        {
            return await Mapper.Map<Task<CustomerViewModel>>(_customersRepository.GetByIdAsync(request.Id));
        }
    }
}
