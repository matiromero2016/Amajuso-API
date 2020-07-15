using Amajuso.Domain.Entities;
using Amajuso.Domain.Paged;
using Amajuso.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Amajuso.Domain.Interfaces
{
    public interface IYoutubeService<T> where T : Youtube
    {
        Task<T> Get(string youtubeId);
        Task<IEnumerable<T>> GetLastVideos();
        Task<PagedCollection<T>> Where(Expression<Func<T, bool>> expression, int page = 1, int pageSize = 10);
        Task<T> Post(T obj); 
    }
}
