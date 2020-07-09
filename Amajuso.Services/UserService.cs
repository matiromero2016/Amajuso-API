using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using Amajuso.Service;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amajuso.Services {
    public class UserService : IService<User>  {

        private IRepository<User> _repository;
        public UserService(IRepository<User> repository) {
            _repository = repository;
        }

        public Task<bool> Delete(long value)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(Expression<Func<User, bool>> expression)
        {
            return await _repository.ExistAsync(expression);
        }

        public async Task<User> Get(long value)
        {
            return await _repository.SelectAsync(value);
        }

        public async Task<User> Post(User obj)
        {
            obj.Password = CryptographyService.Hash(obj.Password);
            obj = await _repository.InsertAsync(obj);

            return obj;
        }

        public Task<User> Put(User obj)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedCollection<User>> Where(Expression<Func<User, bool>> expression, int page = 1, int pageSize = 10)
        {
            return new PagedCollection<User>
            {
                Items = await _repository.SelectAsync(expression, page, pageSize),
                Count = await _repository.CountAsync(expression),
                PageSize = pageSize,
                CurrentPage = page
            };
        }

    }
}