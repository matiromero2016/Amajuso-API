using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Paged;

namespace Amajuso.Domain.Interfaces {

    public interface IService<T> where T : BaseEntity {

        Task<T> Get(long value);
        Task<PagedCollection<T>> Where(Expression<Func<T, bool>> expression, int page = 1, int pageSize = 10);
        Task<T> Post(T obj);
        Task<T> Put(T obj);
        Task<bool> Delete(long value);
        Task<bool> Exist(Expression<Func<T, bool>> expression); 

    }
}