using MediatR;
using System;

namespace Store.Application.ModelsCqrs.Commands
{
    public class RemoveCustomer : IRequest
    {
        public RemoveCustomer(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
