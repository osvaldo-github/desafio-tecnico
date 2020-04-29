namespace WebApi.Modules.Common
{
    using Application.Boundaries.CalculaJuros;
    using Application.Boundaries.GetTaxaJuros;
    using FluentMediator;
    using Microsoft.Extensions.DependencyInjection;

    public static class FluentMediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddFluentMediator(
                builder =>
                {
                    builder.On<CalculaJurosInput>().PipelineAsync()
                        .Call<Application.Boundaries.CalculaJuros.IUseCase>((handler, request) => handler.Execute(request));

                    builder.On<GetTaxaJurosInput>().PipelineAsync()
                        .Call<Application.Boundaries.GetTaxaJuros.IUseCase>((handler, request) => handler.Execute(request));
                });

            return services;
        }
    }
}
