using System;
using MediatR;

namespace Store.Application.ModelsCqrs
{
    public class GetCustomerById : IRequest<CustomerViewModel>
    {
        public GetCustomerById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
