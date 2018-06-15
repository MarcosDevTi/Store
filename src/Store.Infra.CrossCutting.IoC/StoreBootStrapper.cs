using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Handlers;
using Store.Application.ModelsCqrs.Commands;
using Store.Application.ModelsCqrs.Events;
using Store.Domain.Repositories;
using Store.Domain.UoW;
using Store.DomainShared.Bus;
using Store.DomainShared.Events;
using Store.DomainShared.Notifications;
using Store.Infra.CrossCutting.Bus;
using Store.Infra.Data.Context;
using Store.Infra.Data.EventSourcing;
using Store.Infra.Data.Repositories;
using Store.Infra.Data.Repositories.EventSourcing;
using Store.Infra.Data.UoW;

namespace Store.Infra.CrossCutting.IoC
{
    public class StoreBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(config.GetConnectionString("StoreConnection")));


            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomersRepository, CustomersRepository>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomer>, CustomerCommandHandler>();
        }
    }
}
