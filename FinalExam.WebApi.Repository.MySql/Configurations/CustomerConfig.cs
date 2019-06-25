using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer")
                .HasKey(c => c.CustomerId)
                .HasName("customer_id_pkey");

            builder.Property(e => e.CustomerId)
                .HasColumnName("customerId")
                .ValueGeneratedOnAdd();

            builder.HasIndex(e => e.SupportRepId)
                    .HasName("Customer_SupportRepId_idx");

            builder.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(70);

            builder.Property(e => e.City)
                    .HasMaxLength(40)
                    .HasColumnName("city");

            builder.Property(e => e.Company)
                    .HasMaxLength(80)
                    .HasColumnName("company");

            builder.Property(e => e.Country)
                    .HasMaxLength(40)
                    .HasColumnName("country");

            builder.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsRequired()
                    .HasMaxLength(60);

            builder.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .HasColumnName("fax");

            builder.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("first_name");

            builder.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

            builder.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");

            builder.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

            builder.Property(e => e.State)
                    .HasMaxLength(40)
                    .HasColumnName("state");

            builder.HasOne(d => d.SupportRep)
                .WithMany(p => p.Customer)
                .HasForeignKey(d => d.SupportRepId)
                .HasConstraintName("Customer_SupportRepId_fkey");
        }
    }
}
