using Amajuso.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Amajuso.Infra.Mapping
{
    public class ArticleCategoriesMap<T> : BaseMap<T> where T : ArticleCategories
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.HasIndex(u => u.Title).IsUnique();
            
            builder.HasData(
                new ArticleCategories { Id = 1, Title =  "Judicial", Active = true },
                new ArticleCategories { Id = 2, Title =  "Eventos", Active = true}
                );
        }
    }
}