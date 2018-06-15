using Store.DomainShared.Events;
using System;
using System.Collections.Generic;

namespace Store.Infra.Data.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
