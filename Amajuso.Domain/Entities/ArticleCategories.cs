using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amajuso.Domain.Entities
{
    public class ArticleCategories : BaseEntity
    {
       [Required]
       public string Title { get; set; }
       public bool Active { get; set; }
    }
}
