using AutoMapper;
using MediatR;
using Store.Application.Automapper;
using Store.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.ModelsCqrs.Commands
{
    public class CustomerCreate : IRequest, ICustomMappings
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string AddressEmail { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CustomerCreate, Customer>()


                .ConstructProjectionUsing(src => new Customer()
                    .SetName(src.FirstName, src.LastName)
                    .SetAddress(src.Street, src.Number, src.ZipCode, src.City)
                    .SetEmail(src.AddressEmail)
                );
        }
    }
}
