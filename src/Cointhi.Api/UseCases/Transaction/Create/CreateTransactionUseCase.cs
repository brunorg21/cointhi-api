using Cointhi.Api.Database.Repositories;
using Cointhi.Api.Database.Repositories.Transaction;
using Cointhi.Api.DTOs.Requests.Transaction;
using Cointhi.Api.DTOs.Response.Transaction;
using Cointhi.Api.Enums;
using FluentValidation;

namespace Cointhi.Api.UseCases.Transaction.Create
{
    public class CreateTransactionUseCase(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork) : ICreateTransactionUseCase
    {
        public async Task<CreateTransactionResponse> Execute(CreateTransactionRequest request, Guid userId, CancellationToken cancellationToken)
        {
            Validate(request);

            var transaction = new Entities.Transaction
            {
                Title = request.Title,
                Amount = request.Amount,
                Description = request.Description,
                TransactionType = request.Type,
                UserId = userId
            };

            var entity = await transactionRepository.Add(transaction);

            await unitOfWork.Commit(cancellationToken);

            return new CreateTransactionResponse
            {
                Id = entity.Id,
                TransactionType = entity.TransactionType.ToValue(),
                Amount = entity.Amount,
                CreatedAt = entity.CreatedAt,
                Description = entity.Description,
                Title = entity.Title,
                UpdatedAt = entity.UpdatedAt
            };
        }

        private void Validate(CreateTransactionRequest request)
        {
            var validator = new CreateTransactionValidator();

            var validationResult = validator.Validate(request);

            if(!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
