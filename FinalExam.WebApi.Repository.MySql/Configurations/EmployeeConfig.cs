using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("employee")
                .HasKey(a => a.EmployeeId)
                .HasName("employee_id_pkey");

            builder.HasIndex(e => e.ReportsTo)
                .HasName("Employee_ReportsTo_idx");

            builder.Property(e => e.EmployeeId)
                .HasColumnName("employeeId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Address)
                .HasMaxLength(70)
                .HasColumnName("address");

            builder.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birthdate");

            builder.Property(e => e.City)
                .HasMaxLength(40)
                .HasColumnName("city");

            builder.Property(e => e.Country)
                .HasMaxLength(40)
                .HasColumnName("country");

            builder.Property(e => e.Email)
                .HasMaxLength(60)
                .HasColumnName("email");

            builder.Property(e => e.Fax)
                .HasMaxLength(24)
                .HasColumnName("fax");

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(20);

            builder.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("hire_date");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("last_name");

            builder.Property(e => e.Phone)
                .HasMaxLength(24)
                .HasColumnName("phone");

            builder.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postalCode");

            builder.Property(e => e.State)
                .HasMaxLength(40)
                .HasColumnName("state");

            builder.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");

            builder.HasOne(d => d.ReportsToNavigation)
                .WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("Employee_ReportsTo_fkey");
        }
    }
}
