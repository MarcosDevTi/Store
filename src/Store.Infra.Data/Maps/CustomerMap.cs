using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

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
                        .HasColumnType("varchar(30)")
                        .IsRequired();
                    cb.Property(c => c.LastName)
                        .HasColumnName("LastName")
                        .HasColumnType("varchar(50)")
                        .IsRequired();
                });

            builder
                .OwnsOne(s => s.Email, cb =>
                {
                    cb.Property(c => c.AddressEmail)
                        .HasColumnName("Email")
                        .HasColumnType("varchar(120)")
                        .IsRequired();
                });

            builder
                .OwnsOne(s => s.Address, cb =>
                {
                    cb.Property(c => c.City)
                        .HasColumnName("City")
                        .HasColumnType("varchar(50)")
                        .IsRequired();
                    cb.Property(c => c.Number)
                        .HasColumnName("Number")
                        .HasColumnType("varchar(20)")
                        .IsRequired();
                    cb.Property(c => c.Street)
                        .HasColumnName("Street")
                        .HasColumnType("varchar(80)")
                        .IsRequired();
                    cb.Property(c => c.ZipCode)
                        .HasColumnName("ZipCode")
                        .HasColumnType("varchar(30)")
                        .IsRequired();
                });
        }
    }
}
