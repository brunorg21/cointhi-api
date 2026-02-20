using Cointhi.Api.DTOs.Requests;
using Cointhi.Api.UseCases.Auth.Login;
using Cointhi.Api.UseCases.Auth.Register;

namespace Cointhi.Api.Controllers.Auth
{
    public static class MapAuthController
    {
        private const string BASE_ROUTE = "/auth";
        public static void MapAuthRoutesApi(this IEndpointRouteBuilder app)
        {
            var authRouteGroup = app.MapGroup(BASE_ROUTE);

            authRouteGroup.MapPost("/register", async (RegisterUserRequest request, IRegisterUserUseCase useCase, CancellationToken cancellationToken) =>
            {
                await useCase.Execute(request, cancellationToken);

                return Results.Created(); 
            });

            authRouteGroup.MapPost("/login", async (LoginRequest request, ILoginUseCase useCase, CancellationToken cancellationToken) =>
            {
                var response = await useCase.Execute(request, cancellationToken);

                return Results.Ok(response); 
            });

        }
    }
}
