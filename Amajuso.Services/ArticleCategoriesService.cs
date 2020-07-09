using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Domain.Paged;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amajuso.Services
{
    public class ArticleCategoriesService : IService<ArticleCategories>
    {
        private IRepository<ArticleCategories> _repository;

        public ArticleCategoriesService(IRepository<ArticleCategories> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(long value)
        {
            return await _repository.DeleteAsync(value);
        }

        public async Task<bool> Exist(Expression<Func<ArticleCategories, bool>> expression)
        {
            return await _repository.ExistAsync(expression);
        }

        public async Task<ArticleCategories> Get(long value)
        {
            return await _repository.SelectAsync(value);
        }

        public async Task<ArticleCategories> Post(ArticleCategories obj)
        {
            return await _repository.InsertAsync(obj);
        }

        public async Task<ArticleCategories> Put(ArticleCategories obj)
        {
            return await _repository.UpdateAsync(obj);
        }

        public async Task<PagedCollection<ArticleCategories>> Where(bool active, int page = 0, int pageSize = 10)
        {
            return new PagedCollection<ArticleCategories>
            {
                Items = await _repository.SelectAsync(x=> x.Active == active, page, pageSize),
                Count = await _repository.CountAsync(x=> x.Active == active),
                PageSize = pageSize,
                CurrentPage = page
            };
        }

        public Task<PagedCollection<ArticleCategories>> Where(Expression<Func<ArticleCategories, bool>> expression, int page = 0, int pageSize = 10)
        {
            throw new NotImplementedException();
        }


        //private Expression<Func<T, bool>> Predicate(string Title, Status? Status, List<long> Companies, DateTime? Start, DateTime? End, long? UserId, string Culture, bool Current, bool OnlyFavorite)
        //{
        //    Expression<Func<T, bool>> predicate = PredicateBuilder.True<T>();

        //    predicate = predicate.And(x => x.Culture.Equals(Culture));

        //    if (Status != null)
        //        predicate = predicate.And(x => x.Status.Equals(Status));

        //    if (string.IsNullOrWhiteSpace(Title) == false)
        //        predicate = predicate.And(x => x.Title.Contains(Title));

        //    if (Companies != null && Companies.Count() > 0)
        //    {
        //        predicate = predicate.And(x => x.Companies.Any(c => Companies.Contains(c.CompanyId)));
        //    }

        //    if (Current)
        //    {
        //        //predicate = predicate.And(x => x.DateInitial >= DateTime.UtcNow.Date);
        //        predicate = predicate.And(x => x.DateInitial <= DateTime.Now && DateTime.Now <= x.DateFinish);
        //    }
        //    else
        //    {
        //        if (End != null)
        //        {
        //            End = new DateTime(End.Value.Year, End.Value.Month, End.Value.Day, 23, 59, 59, 999);
        //            predicate = predicate.And(x => x.DateInitial <= End);
        //        }

        //        if (Start != null)
        //            predicate = predicate.And(x => x.DateFinish >= Start);
        //    }

        //    if (UserId != null)
        //    {
        //        var user = accountRepository.Select(UserId.Value);
        //        if (user.Type == Role.Marketing || user.Type == Role.Operational)
        //        {
        //            var userCompanies = user.Companies.Select(p => p.CompanyId)?.ToArray();
        //            predicate = predicate.And(x => x.Companies.All(c => userCompanies.Contains(c.CompanyId)));
        //        }

        //        if (OnlyFavorite)
        //        {
        //            var favorites = favoritesRepository.Where(f => f.AccountId.Equals(UserId), 1, 500).Select(f => f.CompanyId).ToArray();
        //            predicate = predicate.And(x => x.Companies.Any(c => favorites.Contains(c.CompanyId)));
        //        }
        //    }

        //    return predicate;
        //}
    }
}
