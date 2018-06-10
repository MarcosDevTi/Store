using System.Collections.Generic;
using MediatR;

namespace Store.Application.ModelsCqrs
{
    public class GetAllCustomers : IRequest<IReadOnlyList<CustomerViewModel>>
    {
    }
}
