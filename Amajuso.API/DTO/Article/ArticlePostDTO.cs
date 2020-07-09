using Amajuso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amajuso.API.DTO
{
    public class ArticlePostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public long CategoryId { get; set; }

        public Article ToModel()
        {
            return new Article
            {
                Title = this.Title,
                Content = this.Content,
                ArticleCategoryId = this.CategoryId
            };

        }
    }
}
