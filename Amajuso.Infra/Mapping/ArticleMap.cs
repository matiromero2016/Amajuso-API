using Amajuso.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amajuso.Infra.Mapping
{
    public class ArticleMap<T> : BaseMap<T> where T : Article
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            
            builder.HasData(
                new Article { Id = 1, Title =  "Primera noticia de Amajuso", UserId = 1, ArticleCategoryId = 1, Content= "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>" },
                new Article { Id = 2, Title =  "Nueva charla por Zoom", UserId= 1, ArticleCategoryId = 2, Content="<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>"}
                );
        }
    }
}
