using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Amajuso.Domain.Entities;

namespace Amajuso.Domain.Interfaces {

    public interface IRepository<T> where T : BaseEntity {

        Task<T> InsertAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(long id);
        Task<T> SelectAsync(long id);
        // void Delete(long id);
        Task<IEnumerable<T>> SelectAsync(Expression<Func<T, bool>> expression, int page, int pageSize, params Expression<Func<T, object>>[] includes);
        Task<int> CountAsync(Expression<Func<T, bool>> expression);
        Task<bool> ExistAsync(Expression<Func<T, bool>> expression);

    }
}