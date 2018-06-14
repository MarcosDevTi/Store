using Store.DomainShared.Cqrs.Commands;
using Store.DomainShared.FinalValues;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.ModelsCqrs.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "The First Name is Required")]
        [MinLength(CustomerConsts.FirstNameMinLength), MaxLength(CustomerConsts.FirstNameMaxLength)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is Required")]
        [MinLength(CustomerConsts.LastNameMinLength), MaxLength(CustomerConsts.LastNameMaxLength)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Street is Required")]
        [MinLength(CustomerConsts.StreetMinLength), MaxLength(CustomerConsts.StreetMaxLength)]
        [DisplayName("Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "The Number is Required")]
        [MinLength(CustomerConsts.NumberMinLength), MaxLength(CustomerConsts.NumberMaxLength)]
        [DisplayName("Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "The Zip Code is Required")]
        [MinLength(CustomerConsts.ZipCodeMinLength), MaxLength(CustomerConsts.ZipCodeMaxLength)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "The City is Required")]
        [MinLength(CustomerConsts.CityMinLength), MaxLength(CustomerConsts.FirstNameMaxLength)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [MaxLength(CustomerConsts.EmailMaxLength)]
        [DisplayName("E-mail")]
        public string AddressEmail { get; set; }

        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
    }
}
