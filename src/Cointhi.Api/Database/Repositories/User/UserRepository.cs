
using Microsoft.EntityFrameworkCore;

namespace Cointhi.Api.Database.Repositories.User
{
    public class UserRepository(CointhiDbContext _dbContext) : IUserRepository
    {
        public async Task Add(Entities.User user, CancellationToken cancellationToken)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);
        }

        public async Task<Entities.User?> GetByEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

            return user;
        }

        public async Task<Entities.User?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

            return user;
        }
    }
}
