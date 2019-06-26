using FinalExam.WebApi.Repository.MySql;
using GenFu;

namespace FinalExam.WebApi.Tests.Builder.Data
{
    public partial class ChinookDbContextBuilder
    {
        public ChinookDbContextBuilder AddTenAlbum()
        {
            AddAlbum(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenArtist()
        {
            AddArtist(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenCustomer()
        {
            AddCustomer(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenEmployee()
        {
            AddEmployee(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenGenre()
        {
            AddGenre(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenInvoice()
        {
            AddInvoice(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenInvoiLine()
        {
            AddInvoiceLine(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenMediaType()
        {
            AddMediaType(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenPlaylist()
        {
            AddPlaylist(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenPlaylistTrack()
        {
            AddPlaylistTrack(_context, 10);
            return this;
        }

        public ChinookDbContextBuilder AddTenTrack()
        {
            AddTrack(_context, 10);
            return this;
        }

        private void AddAlbum(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddArtist(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddCustomer(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddEmployee(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddGenre(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddInvoice(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddInvoiceLine(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddMediaType(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddPlaylist(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddPlaylistTrack(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
        private void AddTrack(ChinookDbContext context, int quantity)
        {
            var albumList = A.ListOf<Models.Album>(quantity);

            for (int i = 1; i <= quantity; i++)
            {
                albumList[i - 1].AlbumId = i;
            }

            context.Album.AddRange(albumList);
            context.SaveChanges();
        }
    }
}
