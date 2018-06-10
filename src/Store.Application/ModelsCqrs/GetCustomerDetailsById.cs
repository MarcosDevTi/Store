using MediatR;
using System;

namespace Store.Application.ModelsCqrs
{
    public class GetCustomerDetailsById : IRequest<CustomerViewModel>
    {
        public GetCustomerDetailsById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
