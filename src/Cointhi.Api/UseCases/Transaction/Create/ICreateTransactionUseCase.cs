using Cointhi.Api.DTOs.Requests.Transaction;
using Cointhi.Api.DTOs.Response.Transaction;

namespace Cointhi.Api.UseCases.Transaction.Create
{
    public interface ICreateTransactionUseCase
    {
        Task<CreateTransactionResponse> Execute(CreateTransactionRequest request, Guid userId, CancellationToken cancellationToken);
    }
}
