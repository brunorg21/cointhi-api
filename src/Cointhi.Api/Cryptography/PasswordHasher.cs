
using Encrypter = BCrypt.Net;

namespace Cointhi.Api.Cryptography
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Encrypt(string password)
        {
            return Encrypter.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hash)
        {
            return Encrypter.BCrypt.Verify(password, hash);
        }
    }
}
