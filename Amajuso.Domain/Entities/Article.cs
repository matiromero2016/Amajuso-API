using Amajuso.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Amajuso.Domain.Entities {
    public class Article : BaseEntity {

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public long UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public long ArticleCategoryId { get; set; }
        public virtual ArticleCategories ArticleCategory {get;set;}
    }
}