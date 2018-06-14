﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Infra.Data.Repositories;

namespace Store.Infra.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20180614080545_ChangeDataBase")]
    partial class ChangeDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Store.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Store.Domain.Entities.Customer", b =>
                {
                    b.OwnsOne("Store.DomainShared.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid?>("CustomerId");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("City")
                                .HasMaxLength(100);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("Number")
                                .HasMaxLength(20);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("Street")
                                .HasMaxLength(80);

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnName("ZipCode")
                                .HasMaxLength(30);

                            b1.ToTable("Customers");

                            b1.HasOne("Store.Domain.Entities.Customer")
                                .WithOne("Address")
                                .HasForeignKey("Store.DomainShared.ValueObjects.Address", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Store.DomainShared.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid?>("CustomerId");

                            b1.Property<string>("AddressEmail")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasMaxLength(120);

                            b1.ToTable("Customers");

                            b1.HasOne("Store.Domain.Entities.Customer")
                                .WithOne("Email")
                                .HasForeignKey("Store.DomainShared.ValueObjects.Email", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Store.DomainShared.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid?>("CustomerId");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName")
                                .HasMaxLength(40);

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName")
                                .HasMaxLength(120);

                            b1.ToTable("Customers");

                            b1.HasOne("Store.Domain.Entities.Customer")
                                .WithOne("Name")
                                .HasForeignKey("Store.DomainShared.ValueObjects.Name", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
