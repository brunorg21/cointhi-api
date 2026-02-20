namespace Cointhi.Api.Database.Repositories.User
{
    public interface IUserRepository
    {
        Task Add(Entities.User user, CancellationToken cancellationToken);
        Task<Entities.User?> GetById(Guid id, CancellationToken cancellationToken);
        Task<Entities.User?> GetByEmail(string email, CancellationToken cancellationToken);
    }
}
