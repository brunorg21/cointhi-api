namespace Cointhi.Api.Database.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken);
    }
}
