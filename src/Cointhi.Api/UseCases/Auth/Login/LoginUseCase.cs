using Cointhi.Api.Cryptography;
using Cointhi.Api.Database.Repositories.User;
using Cointhi.Api.DTOs.Requests;
using Cointhi.Api.DTOs.Response;
using Cointhi.Api.Exceptions;
using Cointhi.Api.UseCases.Token;

namespace Cointhi.Api.UseCases.Auth.Login
{
    public class LoginUseCase(IUserRepository userRepository, IGenerateToken generateToken, IPasswordHasher hasher) : ILoginUseCase
    {
        public async Task<LoginResponse> Execute(LoginRequest request, CancellationToken cancellationToken)
        {
            var existsUser = await userRepository.GetByEmail(request.Email, cancellationToken);

            if (existsUser is null)
            {
                throw new InvalidCredentialsException();
            }

            var isPasswordMatch = hasher.Verify(request.Password, existsUser.Password);

            if(!isPasswordMatch)
            {
                throw new InvalidCredentialsException();
            }

            var token = generateToken.GenerateToken(existsUser.Id, existsUser.Email);

            return new LoginResponse 
            { 
                Token = token,
                User = new LoggedUserResponse 
                { 
                    Id = existsUser.Id, 
                    Name = existsUser.Name, 
                    Email = existsUser.Email,
                    CreatedAt = existsUser.CreatedAt,
                    UpdatedAt = existsUser.UpdatedAt
                }
            };

        }
    }
}
