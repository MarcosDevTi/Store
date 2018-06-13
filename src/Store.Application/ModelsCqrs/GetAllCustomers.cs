using System;
using MediatR;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Domain.Entities;

namespace Store.Application.ModelsCqrs
{
    public class GetAllCustomers : IRequest<IReadOnlyList<CustomerViewModel>>
    {
        public GetAllCustomers(string sortOrder, Expression<Func<Customer, bool>> predicate)
        {
            SortOrder = sortOrder;
            Predicate = predicate;
        }
        public string SortOrder { get; private set; }
        public Expression<Func<Customer, bool>> Predicate { get; private set; }
    }
}
