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
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly StoreContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(StoreContext db)
        {
            Db = db;
            DbSet = Db.Set<T>();
        }

        public IReadOnlyList<T> GetAll()
        {
            return DbSet.ToList();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public PagingResult<T> GetPage(int skip, int take)
        {
            var entities = DbSet
                .Skip(skip)
                .Take(take)
                .ToList();

            return new PagingResult<T>(entities, DbSet.Count());
        }

        public async Task<PagingResult<T>> GetPageAsync(int skip, int take)
        {
            var entities = await DbSet
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return new PagingResult<T>(entities, await DbSet.CountAsync());
        }

        public T GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return DbSet.FindAsync(id);
        }
    }
}
