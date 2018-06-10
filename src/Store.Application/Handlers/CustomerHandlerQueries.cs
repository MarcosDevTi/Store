using AutoMapper;
using MediatR;
using Store.Application.ModelsCqrs;
using Store.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Application.Handlers
{
    public class CustomerHandlerQueries :
        IRequestHandler<GetAllCustomers, IReadOnlyList<CustomerViewModel>>,
        IRequestHandler<GetCustomerDetailsById, CustomerViewModel>

    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerHandlerQueries(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public async Task<IReadOnlyList<CustomerViewModel>> Handle(GetAllCustomers request, CancellationToken cancellationToken)
        {
            return await Mapper.Map<Task<IReadOnlyList<CustomerViewModel>>>(_customersRepository.GetAllAsync());
        }

        public async Task<CustomerViewModel> Handle(GetCustomerDetailsById request, CancellationToken cancellationToken)
        {
            return await Mapper.Map<Task<CustomerViewModel>>(_customersRepository.GetByIdAsync(request.Id));
        }


    }
}
