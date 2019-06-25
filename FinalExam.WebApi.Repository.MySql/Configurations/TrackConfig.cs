using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class TrackConfig : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("track")
                .HasKey(a => a.TrackId)
                .HasName("track_id_pkey");

            builder.HasIndex(e => e.AlbumId)
                    .HasName("Track_AlbumId_idx");

            builder.HasIndex(e => e.GenreId)
                .HasName("Track_GenreId_idx");

            builder.HasIndex(e => e.MediaTypeId)
                .HasName("Track_MediaTypeId_idx");

            builder.Property(e => e.TrackId)
                .HasColumnName("trackId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Composer)
                .HasColumnName("composer")
                .HasMaxLength(220);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(200);

            builder.Property(e => e.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("numeric(10, 2)");

            builder.HasOne(d => d.Album)
                .WithMany(p => p.Track)
                .HasForeignKey(d => d.AlbumId)
                .HasConstraintName("Track_AlbumId_fkey");

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Track)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("Track_GenreId_fkey");

            builder.HasOne(d => d.MediaType)
                .WithMany(p => p.Track)
                .HasForeignKey(d => d.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Track_MediaTypeId_fkey");
        }
    }
}
