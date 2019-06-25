using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre")
                .HasKey(a => a.GenreId)
                .HasName("genre_id_pkey");

            builder.Property(e => e.GenreId)
                .HasColumnName("genreId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("name");
        }
    }
}
