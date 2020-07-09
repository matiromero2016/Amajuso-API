using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Amajuso.Infra.Repository {

    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DefaultContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(DefaultContext context) {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                expression = x => true;

            return await _dataset.CountAsync(expression);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try {
           var obj = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
           if (obj == null)
           return false;

           _dataset.Remove(obj);
           await _context.SaveChangesAsync();
           return true;
           }
           catch(Exception ex) {
               throw ex;
           }
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> expression)
        {
            try {
                return await _dataset.AnyAsync(expression);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T obj)
        {
            try 
            {
                _dataset.Add(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex){
                throw ex;
            }
            return obj;
        }
        public async Task<T> SelectAsync(long id)
        {
            return await SelectAsync(id, false);
        }

        public async Task<T> SelectAsync(long id, bool asNoTracking = false)
        {
            try {
                if(asNoTracking) {
                    return await _dataset.AsNoTracking().SingleOrDefaultAsync(p=> p.Id.Equals(id));
                }
                return await _dataset.SingleOrDefaultAsync(p=> p.Id.Equals(id));
            }
            catch (Exception ex){
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> expression, int page, int pageSize, params Expression<Func<T, object>>[] includes)
        {
            try {
                IQueryable<T> queryable = _dataset.AsNoTracking<T>();

            if (expression != null)
            {
                queryable = queryable.Where(expression);
            }

            if (includes != null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    queryable = queryable.Include(include);
                }
            }

                return await queryable.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T obj)
        {
            try {
                obj.Modified = DateTime.UtcNow;
                _context.Entry(obj).State = EntityState.Modified;
               await _context.SaveChangesAsync();
            }
            catch (Exception ex){
                throw ex;
            }
            return obj;
        }
    }
}