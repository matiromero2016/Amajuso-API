using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amajuso.Services
{
    public class BlackListService : IService<BlackList>
    {
        private IRepository<BlackList> _repository;
        
        public BlackListService(IRepository<BlackList> repository)
        {
            _repository = repository;
        }

        public Task<bool> Delete(long value)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(Expression<Func<BlackList, bool>> expression)
        {
            return await _repository.ExistAsync(expression); 
        }

        public async Task<BlackList> Get(long value)
        {
            return await _repository.SelectAsync(value);
        }

        public async Task<BlackList> Post(BlackList obj)
        {
            return await _repository.InsertAsync(obj);
        }

        public Task<BlackList> Put(BlackList obj)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedCollection<BlackList>> Where(Expression<Func<BlackList, bool>> expression, int page = 1, int pageSize = 10)
        {
            return new PagedCollection<BlackList>
            {
                Items = await _repository.SelectAsync(expression, page, pageSize),
                Count = await _repository.CountAsync(expression),
                PageSize = pageSize,
                CurrentPage = page
            };
        }
    }
}
