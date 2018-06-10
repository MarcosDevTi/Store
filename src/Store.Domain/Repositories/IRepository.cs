using Store.DomainShared;
using Store.DomainShared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IReadOnlyList<T> GetAll();
        Task<IReadOnlyList<T>> GetAllAsync();
        PagingResult<T> GetPage(int skip, int take);
        Task<PagingResult<T>> GetPageAsync(int skip, int take);
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
    }
}
