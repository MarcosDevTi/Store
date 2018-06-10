using Microsoft.EntityFrameworkCore;
using Store.Domain.Repositories;
using Store.DomainShared;
using Store.DomainShared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infra.Data.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : Entity
    {
        protected readonly StoreContext Db;
        protected readonly DbSet<T> DbSet;

        public RepositoryAsync(StoreContext db, DbSet<T> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }
        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<PagingResult<T>> GetPage(int skip, int take)
        {
            var entities = await DbSet
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return new PagingResult<T>(entities, await DbSet.CountAsync());
        }

        public async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
