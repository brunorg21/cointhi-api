using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cointhi.Api.Entities
{
    public class TransactionCategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TransactionId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Transaction Transaction { get; set; } = null!;
        public Category Category { get; set; } = null!;

    }
}
