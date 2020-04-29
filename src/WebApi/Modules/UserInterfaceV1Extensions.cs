namespace WebApi.Modules
{
    using Microsoft.Extensions.DependencyInjection;
    using UseCases.V1.CalculaJuros;
    using WebApi.UseCases.V1.GetTaxaJuros;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<CalculaJurosPresenter, CalculaJurosPresenter>();
            services.AddScoped<Application.Boundaries.CalculaJuros.IOutputPort>(x =>
                x.GetRequiredService<CalculaJurosPresenter>());

            services.AddScoped<GetTaxaJurosPresenter, GetTaxaJurosPresenter>();
            services.AddScoped<Application.Boundaries.GetTaxaJuros.IOutputPort>(x =>
                x.GetRequiredService<GetTaxaJurosPresenter>());

            return services;
        }
    }
}
