using Domain.Shared;
using Domain.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Store.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IReadOnlyList<T> GetAll();
        PagingResult<T> GetPage(int skip, int take);
        T GetById(Guid id);
    }
}
