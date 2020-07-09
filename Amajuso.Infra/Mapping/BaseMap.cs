using Amajuso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amajuso.Infra.Mapping {
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);            

            builder.Property(c => c.Created)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.Modified)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");      
        }
    }
}