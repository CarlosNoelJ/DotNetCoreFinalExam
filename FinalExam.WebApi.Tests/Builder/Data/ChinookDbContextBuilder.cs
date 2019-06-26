using FinalExam.WebApi.Repository.MySql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExam.WebApi.Tests.Builder.Data
{
    public partial class ChinookDbContextBuilder : IDisposable
    {
        private ChinookDbContext _context;

        public ChinookDbContextBuilder ConfigureInMemory()
        {
            var options = new DbContextOptionsBuilder<ChinookDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;

            _context = new ChinookDbContext(options);
            return this;
        }

        public ChinookDbContext Build()
        {
            return _context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
