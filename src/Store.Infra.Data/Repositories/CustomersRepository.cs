using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.UoW;
using System;
using System.Threading.Tasks;

namespace Store.Infra.Data.Repositories
{
    public class CustomersRepository : Repository<Customer>, ICustomersRepository
    {
        private readonly IUnitOfWork _uow;

        public CustomersRepository(StoreContext storeContext, IUnitOfWork uow)
            : base(storeContext)
        {
            _uow = uow;
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await DbSet.SingleOrDefaultAsync(c => c.Email.AddressEmail == email);
        }

        public Task AddAsync(Customer customer)
        {
            DbSet.AddAsync(customer);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Guid id)
        {
            var customer = DbSet.FindAsync(id);
            DbSet.Remove(customer.Result);
            return null;
        }
    }
}
