namespace Cointhi.Api.Database.Repositories.Transaction
{
    public interface ITransactionRepository
    {
        Task<Entities.Transaction> Add(Entities.Transaction transaction);

        Task<List<Entities.Transaction>> GetAll();
    }
}
