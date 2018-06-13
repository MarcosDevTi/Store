using Store.DomainShared.Cqrs.Commands;
using System;

namespace Store.Application.ModelsCqrs.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Street { get; protected set; }
        public string Number { get; protected set; }
        public string ZipCode { get; protected set; }
        public string City { get; protected set; }
        public string AddressEmail { get; protected set; }
    }
}
