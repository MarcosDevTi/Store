using Store.Domain.Entities;
using System.Threading.Tasks;

namespace Store.Domain.Repositories
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        Task<Customer> GetByEmailAsync(string email);
    }
}
