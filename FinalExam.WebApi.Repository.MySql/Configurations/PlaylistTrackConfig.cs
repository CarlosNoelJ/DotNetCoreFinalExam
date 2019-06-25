using FinalExam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalExam.WebApi.Repository.MySql.Configurations
{
    internal class PlaylistTrackConfig : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder.ToTable("playlistTrack")
                .HasKey(e => new { e.PlaylistId, e.TrackId })
                .HasName("playlistId_tracklistId_pkey");

            builder.HasKey(e => new { e.PlaylistId, e.TrackId })
                    .HasName("playlistId_trackId_pkey");

            builder.HasIndex(e => e.TrackId)
                .HasName("playlist_trackTrackId_idx");

            builder.HasOne(d => d.Playlist)
                .WithMany(p => p.PlaylistTrack)
                .HasForeignKey(d => d.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlaylistTrack_PlaylistId_fkey");

            builder.HasOne(d => d.Track)
                .WithMany(p => p.PlaylistTrack)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlaylistTrack_TrackId_fkey");
        }
    }
}
