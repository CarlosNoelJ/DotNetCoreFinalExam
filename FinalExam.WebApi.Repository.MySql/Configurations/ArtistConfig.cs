using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("artist")
                .HasKey(a => a.ArtistId)
                .HasName("artist_id_pkey");

            builder.Property(a => a.ArtistId)
                .HasColumnName("artistId")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .HasColumnName("name")
                .HasMaxLength(120);
        }
    }
}
