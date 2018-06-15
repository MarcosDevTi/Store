using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Store.Infra.Data.Context;

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

        public async Task<IReadOnlyList<Customer>> GetAllAsync(string order, Expression<Func<Customer, bool>> predicate)
        {

            return await Task.Run(() => DbSet.Where(predicate).ToList());
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
