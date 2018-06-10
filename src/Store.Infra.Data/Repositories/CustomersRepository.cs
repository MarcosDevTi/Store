using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using System.Threading.Tasks;

namespace Store.Infra.Data.Repositories
{
    public class CustomersRepository : Repository<Customer>, ICustomersRepository
    {
        public CustomersRepository(StoreContext storeContext)
            : base(storeContext)
        {

        }
        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await DbSet.SingleOrDefaultAsync(c => c.Email.AddressEmail == email);
        }
    }
}
