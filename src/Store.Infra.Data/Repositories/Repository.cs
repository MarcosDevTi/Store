using Domain.Shared;
using Domain.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly StoreContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(StoreContext db, DbSet<T> dbSet)
        {
            Db = db;
            DbSet = dbSet;
        }
        public IReadOnlyList<T> GetAll()
        {
            return DbSet.ToList();
        }

        public PagingResult<T> GetPage(int skip, int take)
        {
            var entities = DbSet
                .Skip(skip)
                .Take(take)
                .ToList();

            return new PagingResult<T>(entities, DbSet.Count());
        }

        public T GetById(Guid id)
        {
            return DbSet.Find(id);
        }
    }
}
