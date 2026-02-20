using Cointhi.Api.DTOs.Requests;

namespace Cointhi.Api.UseCases.Auth.Register
{
    public interface IRegisterUserUseCase
    {
        Task Execute(RegisterUserRequest request, CancellationToken cancellationToken);
    }
}
