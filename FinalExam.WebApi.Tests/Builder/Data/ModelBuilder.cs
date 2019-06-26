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
    }
}
