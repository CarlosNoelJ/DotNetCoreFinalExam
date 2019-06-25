using Microsoft.EntityFrameworkCore;
using System;

namespace FinalExam.WebApi.Repository.MySql
{
    public class ChinookDbContext : DbContext
    {
        public ChinookDbContext(DbContextOptions<ChinookDbContext> options) : base(options)
        {
        }

    }
}
