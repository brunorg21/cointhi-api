
namespace Cointhi.Api.Database.Repositories
{
    public class UnitOfWork(CointhiDbContext _dbContext) : IUnitOfWork
    {
        public async Task Commit(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
