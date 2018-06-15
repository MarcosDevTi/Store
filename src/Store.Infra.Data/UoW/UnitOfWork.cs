using Store.Domain.UoW;
using Store.Infra.Data.Context;
using Store.Infra.Data.Repositories;

namespace Store.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
