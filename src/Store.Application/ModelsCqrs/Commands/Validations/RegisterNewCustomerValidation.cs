namespace Store.Application.ModelsCqrs.Commands.Validations
{
    public class RegisterNewCustomerValidation : CustomerValidation<RegisterNewCustomer>
    {
        public RegisterNewCustomerValidation()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidateEmail();
        }
    }
}
