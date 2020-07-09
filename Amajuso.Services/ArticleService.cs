using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amajuso.Services
{
    public class ArticleService : IService<Article>
    {
        private IRepository<Article> _repository;

        public ArticleService(IRepository<Article> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(long value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<bool> Exist(Expression<Func<Article, bool>> expression)
        {
            return await _repository.ExistAsync(expression);
        }

        public async Task<Article> Get(long value)
        {
            return await _repository.SelectAsync(value);
        }

        public async Task<Article> Post(Article obj)
        {
            return await _repository.InsertAsync(obj);
        }

        public async Task<Article> Post(Article obj, long userId)
        {
            obj.UserId = userId;
            return await _repository.InsertAsync(obj);
        }

        public async Task<Article> Put(Article obj)
        {
            return await _repository.UpdateAsync(obj);
        }

        public async Task<PagedCollection<Article>> Where(long? categoryId = null, int page = 0, int pageSize = 10)
        {
            List<Expression<Func<Article, object>>> includes = new List<Expression<Func<Article, object>>>();

            includes.Add(x => x.ArticleCategory);
            includes.Add(x => x.User);

            return new PagedCollection<Article>
            {
                Items = await _repository.SelectAsync(x=> x.ArticleCategoryId == categoryId, page, pageSize, includes.ToArray()),
                Count = await _repository.CountAsync(x=> x.ArticleCategoryId == categoryId),
                PageSize = pageSize,
                CurrentPage = page
            };
        }

        public async Task<PagedCollection<Article>> Where(Expression<Func<Article, bool>> expression, int page = 0, int pageSize = 10)
        {
            return new PagedCollection<Article>
            {
                Items = (await _repository.SelectAsync(expression, page, pageSize)).OrderByDescending(x=>x.Created),
                Count = await _repository.CountAsync(expression),
                PageSize = pageSize,
                CurrentPage = page
            };
        }
    }
}