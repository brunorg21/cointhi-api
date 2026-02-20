namespace Cointhi.Api.Cryptography
{
    public static class DependencyInjectionExtensions
    {
        public static void AddCryptography(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}
