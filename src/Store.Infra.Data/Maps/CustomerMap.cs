using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;
using Store.DomainShared.FinalValues;

namespace Store.Infra.Data.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .OwnsOne(s => s.Name, cb =>
                {
                    cb.Property(c => c.FirstName)
                        .HasColumnName("FirstName")
                        .HasMaxLength(CustomerConsts.FirstNameMaxLength)
                        .IsRequired();
                    cb.Property(c => c.LastName)
                        .HasColumnName("LastName")
                        .HasMaxLength(CustomerConsts.LastNameMaxLength)
                        .IsRequired();
                });

            builder
                .OwnsOne(s => s.Email, cb =>
                {
                    cb.Property(c => c.AddressEmail)
                        .HasColumnName("Email")
                        .HasMaxLength(CustomerConsts.EmailMaxLength)
                        .IsRequired();
                });

            builder
                .OwnsOne(s => s.Address, cb =>
                {
                    cb.Property(c => c.City)
                        .HasColumnName("City")
                        .HasMaxLength(CustomerConsts.CityMaxLength)
                        .IsRequired();
                    cb.Property(c => c.Number)
                        .HasColumnName("Number")
                        .HasMaxLength(CustomerConsts.NumberMaxLength)
                        .IsRequired();
                    cb.Property(c => c.Street)
                        .HasColumnName("Street")
                        .HasMaxLength(CustomerConsts.StreetMaxLength)
                        .IsRequired();
                    cb.Property(c => c.ZipCode)
                        .HasColumnName("ZipCode")
                        .HasMaxLength(CustomerConsts.ZipCodeMaxLength)
                        .IsRequired();
                });
        }
    }
}
