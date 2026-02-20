using Cointhi.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cointhi.Api.Database.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("name");
            
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("description");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("datetime('now', 'utc')");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
