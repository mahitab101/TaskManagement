﻿using Microsoft.EntityFrameworkCore;
using ProjectManagement.Contracts;
using ProjectManagement.Models;

namespace ProjectManagement.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDBContext _context;

        public BaseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //public Task<bool> DeleteAllAsync()
        //{
        //    throw new NotImplementedException();

        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var entity = await GetAsync(id);
        //    _context.Update(entity);
        //    await _context.SaveChangesAsync();
        //}

        public async Task<bool> Exist(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
