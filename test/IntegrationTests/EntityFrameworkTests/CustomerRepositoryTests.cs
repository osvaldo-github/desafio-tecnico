namespace IntegrationTests.EntityFrameworkTests
{
    using System.Threading.Tasks;
    using Infrastructure.ExternalIntegration.Integration;
    using Microsoft.AspNetCore.Mvc.Testing;
    using WebApi;
    using Xunit;

    public sealed class CustomerRepositoryTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CustomerRepositoryTests(WebApplicationFactory<Startup> factory)
        {
            this._factory = factory;
        }

        [Fact]
        public async Task GetTaxaJuros()
        {
            var financeiroIntegration = new FinanceiroService(_factory.CreateClient());
            var juro = await financeiroIntegration.GetTaxaJuros()
                .ConfigureAwait(false);

            Assert.Equal(0.01m, juro.ToDecimal());
        }
    }
}
