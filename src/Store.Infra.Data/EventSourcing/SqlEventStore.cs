using Newtonsoft.Json;
using Store.DomainShared.Events;
using Store.Infra.Data.Repositories.EventSourcing;

namespace Store.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;


        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "Utilizador");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
