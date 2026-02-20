using Cointhi.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cointhi.Api.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            builder.Property(u => u.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(12);

            builder.Property(u => u.CreatedAt)
                .HasColumnName("created_at")
                .HasDefaultValueSql("datetime('now', 'utc')");

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
