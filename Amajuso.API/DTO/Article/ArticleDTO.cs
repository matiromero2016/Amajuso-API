using Amajuso.API.DTO;
using Amajuso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amajuso.API.DTO
{
    public class ArticleDTO
    {
        public long Id { get; internal set; }
        public string Title { get; internal set; }
        public string Content { get; internal set; }
        public DateTime Created { get; internal set; }
        public UserDTO User { get; internal set; }
        public ArticleCategoriesDTO Category { get; internal set; }

        //public ArticleC
        
        public ArticleDTO(Article obj)
        {
            this.Id = obj.Id;
            this.Title = obj.Title;
            this.Content = obj.Content;
            this.Created = obj.Created;
            this.User = new UserDTO(obj.User);
            this.Category = new ArticleCategoriesDTO(obj.ArticleCategory);
        }

    }
}
