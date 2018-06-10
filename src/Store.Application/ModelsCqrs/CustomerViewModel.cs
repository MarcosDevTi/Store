using AutoMapper;
using Store.Domain.Entities;
using System;
using Store.Application.Automapper;

namespace Store.Application.ModelsCqrs
{
    public class CustomerViewModel : ICustomMappings
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Customer, CustomerViewModel>()
                .ForMember(name => name.Name, opt => opt.MapFrom(src => $"{src.Name.FirstName} {src.Name.LastName}"))
                .ForMember(addess => addess.Address, opt =>
                    opt.MapFrom(src =>
                        $"{src.Address.Street}, {src.Address.Number}, {src.Address.City}, {src.Address.ZipCode}"))
                .ForMember(x => x.Id, opt => opt.MapFrom(a => a.Id));

        }
    }
}
