
using Microsoft.EntityFrameworkCore;

namespace Cointhi.Api.Database.Repositories.Transaction
{
    public class TransactionRepository(CointhiDbContext dbContext) : ITransactionRepository
    {
        public async Task<Entities.Transaction> Add(Entities.Transaction transaction)
        {
            var entry = await dbContext.Transactions.AddAsync(transaction);

            return entry.Entity;
        }

        public async Task<List<Entities.Transaction>> GetAll()
        {
            return await dbContext.Transactions.AsNoTracking().ToListAsync();
        }
    }
}
