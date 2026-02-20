using Cointhi.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cointhi.Api.Database
{
    public class CointhiDbContext : DbContext
    {
        public CointhiDbContext(DbContextOptions<CointhiDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CointhiDbContext).Assembly);
        }
    }
}
