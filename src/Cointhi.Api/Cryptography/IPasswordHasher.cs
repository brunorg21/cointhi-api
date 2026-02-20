namespace Cointhi.Api.Cryptography
{
    public interface IPasswordHasher
    {
        string Encrypt(string password);
        bool Verify(string password, string hash);
    }
}
