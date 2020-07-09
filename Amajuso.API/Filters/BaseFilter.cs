using System;
using System.ComponentModel.DataAnnotations;

namespace Amajuso.API.Filters
{
    public class BaseFilter
    {
        /// <summary>
        /// Número de la página deseada
        /// </summary>
        [Range(1, Double.PositiveInfinity, ErrorMessage = "The field must be between {1} and {2}")]
        public int Page { get; set; }

        /// <summary>
        /// Cantidad de items por página
        /// </summary>
        [Range(1, 300, ErrorMessage = "The field must be between {1} and {2}")]
        public int PageSize { get; set; }
    }
}