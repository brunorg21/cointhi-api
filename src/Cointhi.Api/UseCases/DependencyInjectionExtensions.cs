using Cointhi.Api.UseCases.Auth.Login;
using Cointhi.Api.UseCases.Auth.Register;
using Cointhi.Api.UseCases.Token;
using Cointhi.Api.UseCases.Transaction.Create;

namespace Cointhi.Api.UseCases
{
    public static class DependencyInjectionExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IGenerateToken, GenerateToken>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<ILoginUseCase, LoginUseCase>();
            services.AddScoped<ICreateTransactionUseCase, CreateTransactionUseCase>();
        }
    }
}
