using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Amajuso.Domain.Entities
{
        public class BlackList : BaseEntity
        {
            [Required]
            public string Token { get; set; }

            [Required]
            public string RefreshToken { get; set; }
        }
}
