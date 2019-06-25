using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class InvoiceLineConfig : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("invoiceLine")
                .HasKey(il => il.InvoiceLineId)
                .HasName("invoiceLine_id_pkey");

            builder.HasIndex(e => e.InvoiceId)
                    .HasName("InvoiceLine_InvoiceId_idx");

            builder.HasIndex(e => e.TrackId)
                .HasName("InvoiceLine_TrackId_idx");

            builder.Property(e => e.InvoiceLineId)
                .HasColumnName("invoiceLineId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UnitPrice)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("unit_price");

            builder.HasOne(d => d.Invoice)
                .WithMany(p => p.InvoiceLine)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("InvoiceLine_InvoiceId_fkey");

            builder.HasOne(d => d.Track)
                .WithMany(p => p.InvoiceLine)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("InvoiceLine_TrackId_fkey");
        }
    }
}
