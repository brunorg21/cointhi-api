using Cointhi.Api.DTOs.Requests.Transaction;
using FluentValidation;

namespace Cointhi.Api.UseCases.Transaction.Create
{
    public class CreateTransactionValidator : AbstractValidator<CreateTransactionRequest>
    {
        public CreateTransactionValidator()
        {
            RuleFor(t => t.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(100).WithMessage("Title must be no longer than 100 characters.");
            RuleFor(t => t.Description).MaximumLength(500).WithMessage("Description must be no longer than 500 characters.");
            RuleFor(t => t.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
            RuleFor(t => t.Type).IsInEnum().WithMessage("Invalid transaction type.");
        }
    }
}
