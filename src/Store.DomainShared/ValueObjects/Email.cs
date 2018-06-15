namespace Store.DomainShared.ValueObjects
{
    public class Email
    {
        public Email(string addressEmail)
        {
            AddressEmail = addressEmail;
        }

        public string AddressEmail { get; private set; }

        public override string ToString()
        {
            return AddressEmail;
        }
    }
}
