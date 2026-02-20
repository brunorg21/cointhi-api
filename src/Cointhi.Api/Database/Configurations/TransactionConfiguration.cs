using Cointhi.Api.Entities;
using Cointhi.Api.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cointhi.Api.Database.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(t => t.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Description)
                .HasColumnName("description")
                .HasMaxLength(500);

            builder.Property(t => t.Amount)
                .HasColumnName("amount")
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.TransactionType)
                .HasColumnName("transaction_type")
                .IsRequired()
                .HasDefaultValue(TransactionType.INPUT);

            builder.Property(t => t.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("datetime('now', 'utc')");

            builder.Property(t => t.UpdatedAt)
                .HasColumnName("updated_at");

            builder.HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(u => u.UserId);  
        }
    }
}
