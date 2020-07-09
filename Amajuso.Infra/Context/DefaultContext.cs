using Amajuso.Domain.Entities;
using Amajuso.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Amajuso.Infra.Context {
    public class DefaultContext : DbContext 
    {
        public DbSet<User> User {get;set;}
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleCategories> ArticleCategories { get; set; }
        public DbSet<ArticleFavorite> ArticleFavorite { get; set; }
        public DbSet<CategoryFavorite> CategoryFavorite { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options ) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap<User>().Configure);
            modelBuilder.Entity<Article>(new ArticleMap<Article>().Configure);
            modelBuilder.Entity<ArticleCategories>(new ArticleCategoriesMap<ArticleCategories>().Configure);
            modelBuilder.Entity<ArticleFavorite>(new BaseMap<ArticleFavorite>().Configure);
            modelBuilder.Entity<CategoryFavorite>(new BaseMap<CategoryFavorite>().Configure);

        }
        
    }
}