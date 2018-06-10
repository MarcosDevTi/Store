using Store.DomainShared.Entities;
using Store.DomainShared.ValueObjects;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
       
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }

        public Customer SetName(string firstName, string lastName)
        {
            Name = new Name(firstName, lastName);
            return this;
        }

        public Customer SetAddress(string street, string number, string zipCode, string city)
        {
            Address = new Address(street, number, zipCode, city);
            return this;
        }

        public Customer SetEmail(string emailAddress)
        {
            Email = new Email(emailAddress);
            return this;
        }
    }
}
