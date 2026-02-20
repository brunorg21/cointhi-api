namespace Cointhi.Api.DTOs.Response.Transaction
{
    public class CreateTransactionResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
