using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amajuso.Domain.Entities
{
    public class CategoryFavorite : BaseEntity
    {
        [Required]
        public long ArticleCategoryId { get; set; }

        public virtual ArticleCategories ArticleCategory { get; set; }

        [Required]
        public long UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public bool Notification { get; set; }
    }
}
