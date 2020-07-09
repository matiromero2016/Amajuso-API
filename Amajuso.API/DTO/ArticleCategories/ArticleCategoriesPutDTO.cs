using Amajuso.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Amajuso.API.DTO
{
    public class ArticleCategoriesPutDTO
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool Active { get; set; }

        public ArticleCategories ToModel()
        {
            return new ArticleCategories
            {
                Id = this.Id,
                Title = this.Title,
                Active = this.Active
            };
        }
    }
}