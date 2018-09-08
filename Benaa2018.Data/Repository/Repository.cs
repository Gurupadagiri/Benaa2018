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
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // _context.Update() = System.Data.Entity.EntityState.Deleted

                    //_context.Entry(entity).State = EntityState.Deleted;
                    //if(_context.Entry(entity).State== EntityState.Detached)
                    //{

                    //}
                    
                    _context.Entry(entity).State = EntityState.Detached;
                    
                    //_context.Entry(entity).State = EntityState.Deleted;

                 
                    _context.SaveChanges();
                    
                     _context.UpdateRange(entity);
                    //await _context.AddAsync(entity);
                    //await Save();

                    //await _context.AddAsync(entity);

                    //_context.Entry(entity).State = EntityState.Modified;
                    //await _context.Update(entity);
                    //var group = _context.Group.First(g => g.Id == entity..Group.Id);
                    // _context.Entry(group).CurrentValues.SetValues(entity.Equals()==gr);
                    // await Save();
                    await _context.Entry(entity).GetDatabaseValuesAsync();
                    // _context.Dispose();
                    // _context.Entry(entity).State = EntityState.Detached;
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                return entity;
            }
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
