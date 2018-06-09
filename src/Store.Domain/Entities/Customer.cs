using Domain.Shared.ValueObjects;
using System;

namespace Store.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}
