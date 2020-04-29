namespace ComponentTests
{
    using Domain.Financeiro;
    using Infrastructure.ExternalIntegration.Integration;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;
    using WebApi;

    public sealed class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {

            }).ConfigureServices(services =>
            {
                // Aqui está sendo utilizado o mock para permitir teste na fase do docker
                // Se quiser utilizar o FinanceiroService comente a linha abaixo
                // Se fizer isso garanta que haja uma instancia dessa aplicacao rodando

                services.AddHttpClient<IFinanceiroIntegration, FinanceiroServiceMock>();
            });
        }
    }
}
