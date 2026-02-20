namespace Cointhi.Api.UseCases.Token
{
    public interface IGenerateToken
    {
        string GenerateToken(Guid userId, string email);
    }
}
