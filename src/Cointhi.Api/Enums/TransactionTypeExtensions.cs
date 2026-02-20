namespace Cointhi.Api.Enums
{
    public static class TransactionTypeExtensions
    {
        public static string ToValue(this TransactionType type)
        {
            return type switch
            {
                TransactionType.INPUT => "Input",
                TransactionType.OUTPUT => "Output",
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected TransactionType value: {type}")
            };
        }
    }
}
