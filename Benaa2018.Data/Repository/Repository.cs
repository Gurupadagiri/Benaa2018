using Microsoft.EntityFrameworkCore;
using Benaa2018.Data;
using Benaa2018.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected readonly SBSDbContext _context;
        public Repository(SBSDbContext context)
        {
            _context = context;
        }
        protected async Task Save()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await Task.WhenAll(_context.SaveChangesAsync());
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await Save();
            await _context.Entry(entity).GetDatabaseValuesAsync();
            return entity;
        }

        //public async virtual Task DeleteAsync(T entity)
        //{
        //    await Task.Factory.StartNew(() => _context.Remove(entity));

        //    await Save();
        //}


        public async Task DeleteAsync(T entity)
        {
            await Task.Factory.StartNew(() => _context.Remove(entity));

            await Save();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() => _context.Set<T>());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }



        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                return null;
            }
                        
            //context.Entry(entity).State = EntityState.Modified;
            //_context.Set<T>().Attach(entity);
            await Save();

            return entity;

            //_context.Set<T>().Update(entity);
            //await Save();
            //await _context.Entry(entity).GetDatabaseValuesAsync();
            //return entity;
        }
        
        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            return await Task.Factory.StartNew(() => _context.Set<T>().Where(predicate));
        }

        public async Task<int> CountAsync(Func<T, Boolean> predicate)
        {
            return await Task.Factory.StartNew(() => _context.Set<T>().Where(predicate).Count());
        }

        public async Task<bool> AnyAsync(Func<T, bool> predicate)
        {
            return await Task.Factory.StartNew(() => _context.Set<T>().Any(predicate));
        }

        public async Task<bool> AnyAsync()
        {
            return await _context.Set<T>().AnyAsync();
        }
    }
}
