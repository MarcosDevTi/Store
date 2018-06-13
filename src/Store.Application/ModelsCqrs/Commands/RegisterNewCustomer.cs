using AutoMapper;
using Store.Application.Automapper;
using Store.Application.ModelsCqrs.Commands.Validations;
using Store.Domain.Entities;

namespace Store.Application.ModelsCqrs.Commands
{
    public class RegisterNewCustomer : CustomerCommand, ICustomMappings
    {
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<RegisterNewCustomer, Customer>()

                .ConstructProjectionUsing(src => new Customer()
                    .SetName(src.FirstName, src.LastName)
                    .SetAddress(src.Street, src.Number, src.ZipCode, src.City)
                    .SetEmail(src.AddressEmail)
                );
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
