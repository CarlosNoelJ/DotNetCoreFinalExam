﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalExam.WebApi.Repository.MySql
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ChinookDbContext _db;
        public Repository(ChinookDbContext db)
        {
            _db = db;
        }
        public async Task<int> Create(T entity)
        {
            await _db.AddAsync(entity);
            return await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            _db.Remove(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> Read()
        {
            return await _db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _db.Update(entity);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
