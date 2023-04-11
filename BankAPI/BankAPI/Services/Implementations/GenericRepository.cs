﻿using BankAPI.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankAPI.Services.Implementations
{
    public class GenericRepository<T> where T : class
    {
        private readonly youBankingDbContext _applicationDbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(youBankingDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = applicationDbContext.Set<T>();
        }

        //public async Task<int> InsertAsync(T entity)
        //{
        //    await _dbSet.AddAsync(entity);
        //    await _applicationDbContext.SaveChangesAsync();
        //    return entity.Id;
        //}

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _applicationDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (_applicationDbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public async Task<List<T>> GetAsync(int? skip, int? take, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }

        //public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        //{
        //    IQueryable<T> query = _dbSet;

        //    query = query.Where(entity => entity.Id == id);

        //    foreach (var include in includes)
        //    {
        //        query = query.Include(include);
        //    }

        //    return await query.SingleOrDefaultAsync();
        //}

        public async Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>>[] filters, int? skip, int? take, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }
    }
}
