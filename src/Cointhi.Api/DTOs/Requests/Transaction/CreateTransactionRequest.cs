using Cointhi.Api.Enums;

namespace Cointhi.Api.DTOs.Requests.Transaction
{
    public class CreateTransactionRequest
    {
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; } = string.Empty;
    };
}
