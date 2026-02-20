using Cointhi.Api.DTOs.Requests;
using Cointhi.Api.DTOs.Response;

namespace Cointhi.Api.UseCases.Auth.Login
{
    public interface ILoginUseCase
    {
        Task<LoginResponse> Execute(LoginRequest request, CancellationToken cancellationToken);
    }
}
