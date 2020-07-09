using Amajuso.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Amajuso.API.DTO
{
    public class ArticleCategoriesPostDTO
    {
        [Required]
        public string Title { get; set; }
        public bool Active { get; set; }

        public ArticleCategories ToModel()
        {
            return new ArticleCategories
            {
                Title = this.Title,
                Active = this.Active
            };
        }
    }
}
