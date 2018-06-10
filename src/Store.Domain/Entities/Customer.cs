using Store.DomainShared.Entities;
using Store.DomainShared.ValueObjects;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}
