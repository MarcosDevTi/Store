using System;

namespace Store.Domain.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
