using Store.Domain.UoW;

namespace Store.Application.Handlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Commit()
        {
            //if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;
            //_bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
