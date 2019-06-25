using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("album")
                .HasKey(a => a.AlbumId)
                .HasName("album_id_pkey");

            builder.Property(e => e.AlbumId)
                .HasColumnName("albumId")
                .ValueGeneratedOnAdd();

            builder.HasIndex(a => a.ArtistId)
                .HasName("album_artist_idx");

            builder.Property(a => a.Title)
                .HasColumnName("title")
                .HasMaxLength(160);

            builder.HasOne(a => a.Artist)
                .WithMany(p => p.Album)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlbumArtistId");
        }
    }
}
