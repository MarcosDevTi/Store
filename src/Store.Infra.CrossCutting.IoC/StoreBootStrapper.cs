using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Domain.UoW;
using Store.Infra.Data.Repositories;
using Store.Infra.Data.UoW;

namespace Store.Infra.CrossCutting.IoC
{
    public class StoreBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(config.GetConnectionString("StoreConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomersRepository, CustomersRepository>();
        }
    }
}
