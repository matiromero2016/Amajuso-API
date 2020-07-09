using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;

namespace Amajuso.Services {
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private IRepository<T> _repository;
        public BaseService(IRepository<T> repository) {
            _repository = repository;
        }

        public async Task<bool> Delete(long value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<T> Get(long value)
        {
            return await _repository.SelectAsync(value);
        }

        public async Task<T> Post(T obj)
        {
           return await _repository.InsertAsync(obj);
        }

        public async Task<T> Put(T obj)
        {
            return await _repository.UpdateAsync(obj);
        }

        public async virtual Task<PagedCollection<T>> Where(Expression<Func<T, bool>> expression, int page = 0, int pageSize = 10)
        {
            return new PagedCollection<T>
            {
                Items = await _repository.SelectAsync(expression, page, pageSize),
                Count = await _repository.CountAsync(expression),
                PageSize = pageSize,
                CurrentPage = page
            };
        }

        public async Task<bool> Exist(Expression<Func<T,bool>> expression) {
            return await _repository.ExistAsync(expression);
        }

    }
}