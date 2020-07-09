using Amajuso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amajuso.API.DTO
{
    public class ArticleCategoriesDTO
    {
        public long Id { get; internal set; }
        public string Title { get; internal set; }
        public bool Active { get; internal set; }

        public ArticleCategoriesDTO(ArticleCategories obj)
        {
            this.Id = obj.Id;
            this.Title = obj.Title;
            this.Active = obj.Active;
        }
    }
}
