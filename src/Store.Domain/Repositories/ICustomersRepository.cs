using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Domain.Entities;
using System.Threading.Tasks;

namespace Store.Domain.Repositories
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        Task<Customer> GetByEmailAsync(string email);
        Task<IReadOnlyList<Customer>> GetAllAsync(string order, Expression<Func<Customer, bool>> predicate);
        Task AddAsync(Customer customer);
        Task RemoveAsync(Guid id);
    }
}
