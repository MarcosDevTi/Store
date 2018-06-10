namespace Store.DomainShared.ValueObjects
{
    public class Address
    {
        public Address(string street, string number, string zipCode, string city)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
        }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

    }
}
