using Domain.Shared;
using Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Repositories
{
    public interface IRepositoryAsync<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<PagingResult<T>> GetPage(int skip, int take);
        Task<T> GetById(Guid id);
    }
}
