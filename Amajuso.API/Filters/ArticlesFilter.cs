namespace Amajuso.API.Filters
{
    public class ArticlesFilter : BaseFilter
    {
        /// <summary>
        ///  Busca noticias por categoría
        /// </summary>
        public long? CategoryId { get; set; }
    }
}
