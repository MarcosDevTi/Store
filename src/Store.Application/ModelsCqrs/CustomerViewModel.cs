using AutoMapper;
using Store.Application.Automapper;
using Store.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.ModelsCqrs
{
    public class CustomerViewModel : ICustomMappings
    {
        public Guid Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }

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
