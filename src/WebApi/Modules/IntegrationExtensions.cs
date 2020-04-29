namespace WebApi.Modules
{
    using System;
    using Domain.Financeiro;
    using Infrastructure.ExternalIntegration.Integration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class IntegrationExtensions
    {
        public static IServiceCollection AddIntegration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            string mode = configuration.GetValue<string>("MODE_RUNNING");

            string financeiroBaseUrl = (!string.IsNullOrEmpty(mode) && mode == "DOCKER")
                ? configuration.GetValue<string>("Integration:FinanceiroBaseUrlDocker")
                : configuration.GetValue<string>("Integration:FinanceiroBaseUrl");


            services.AddHttpClient<IFinanceiroIntegration, FinanceiroService>(client =>
            {
                client.BaseAddress = new Uri(financeiroBaseUrl);
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandler(PolicyHandler.GetRetryPolicy())
            .AddPolicyHandler(PolicyHandler.Timeout());

            return services;
        }
    }
}

