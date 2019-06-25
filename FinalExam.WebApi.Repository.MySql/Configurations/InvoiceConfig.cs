using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoice")
                .HasKey(i => i.InvoiceId)
                .HasName("invoice_id_pkey");

            builder.HasIndex(e => e.CustomerId)
                .HasName("invoice_customerId_idx");

            builder.Property(e => e.InvoiceId)
                .HasColumnName("invoiceId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.BillingAddress)
                .HasMaxLength(70)
                .HasColumnName("billing_address");

            builder.Property(e => e.BillingCity)
                .HasMaxLength(40)
                .HasColumnName("billing_city");

            builder.Property(e => e.BillingCountry)
                .HasMaxLength(40)
                .HasColumnName("billing_country");

            builder.Property(e => e.BillingPostalCode)
                .HasMaxLength(10)
                .HasColumnName("billing_postal_code");

            builder.Property(e => e.BillingState)
                .HasMaxLength(40)
                .HasColumnName("billing_state");

            builder.Property(e => e.InvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("invoice_date");

            builder.Property(e => e.Total)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("total");

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Invoice)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Invoice_CustomerId_fkey");
        }
    }
}
