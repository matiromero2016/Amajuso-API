using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amajuso.Domain.Entities
{
    public class ArticleFavorite : BaseEntity
    {
        [Required]
        public long ArticleId { get; set; }
        [Required]
        public long UserId { get; set; }

    }
}
