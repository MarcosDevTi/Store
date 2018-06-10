using System;
using Store.Domain.Entities;
using System.Threading.Tasks;

namespace Store.Domain.Repositories
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        Task<Customer> GetByEmailAsync(string email);
        Task AddAsync(Customer customer);
        Task RemoveAsync(Guid id);
    }
}
