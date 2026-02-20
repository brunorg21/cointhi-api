using Cointhi.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cointhi.Api.Database.Configurations
{
    public class TransactionCategoryConfiguration : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.ToTable("transaction_categories");
            builder.HasKey(tc => tc.Id);

            builder.Property(tc => tc.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(tc => tc.TransactionId)
                .HasColumnName("transaction_id")
                .IsRequired();

            builder.Property(tc => tc.CategoryId)
                .HasColumnName("category_id")
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("datetime('now', 'utc')");

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at");

            builder.HasOne(tc => tc.Transaction)
                .WithMany(t => t.TransactionCategories)
                .HasForeignKey(tc => tc.TransactionId);

            builder.HasOne(tc => tc.Category)
                .WithMany(c => c.TransactionCategories)
                .HasForeignKey(tc => tc.CategoryId);

        }
    }
}
