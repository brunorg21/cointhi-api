using Cointhi.Api.Enums;

namespace Cointhi.Api.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        public ICollection<TransactionCategory> TransactionCategories { get; set; } = new List<TransactionCategory>();
        public User User { get; set; } = null!;
    }
}
