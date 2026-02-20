using Cointhi.Api.DTOs.Requests.Transaction;
using Cointhi.Api.UseCases.Transaction.Create;

namespace Cointhi.Api.Controllers.Auth
{
    public static class MapTransactionController
    {
        public static void MapTransactionRoutesApi(this IEndpointRouteBuilder app)
        {
            var transactionRouteGroup = app.MapGroup("/transactions");

            transactionRouteGroup.MapPost("/", async (
                HttpContext httpContext,
                CreateTransactionRequest request,
                ICreateTransactionUseCase useCase,
                CancellationToken cancellationToken) =>
            {
                string userId = httpContext.User.FindFirst("id")!.Value;

                var response = await useCase.Execute(request, Guid.Parse(userId), cancellationToken);

                return Results.Created(string.Empty, response);
            }).RequireAuthorization();
        }
    }
}
