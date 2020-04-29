namespace WebApi.Modules
{
    using Application.UseCases;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.Boundaries.CalculaJuros.IUseCase, CalculaJurosUseCase>();
            services.AddScoped<Application.Boundaries.GetTaxaJuros.IUseCase, GetTaxaJurosUseCase>();

            return services;
        }
    }
}
