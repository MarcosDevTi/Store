using Store.DomainShared.Entities;
using Store.DomainShared.ValueObjects;
using System;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(DateTime birthDate)
        {
            BirthDate = birthDate;
            Active = true;
        }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }

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

        public Customer Activate(bool value)
        {
            Active = value;
            return this;
        }
    }
}
