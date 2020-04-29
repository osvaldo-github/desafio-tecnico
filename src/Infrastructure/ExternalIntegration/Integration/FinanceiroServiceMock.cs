namespace Infrastructure.ExternalIntegration.Integration
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Domain.Financeiro;
    using Domain.Financeiro.ValueObjects;

    public sealed class FinanceiroServiceMock : IFinanceiroIntegration
    {
        public FinanceiroServiceMock(HttpClient httpClient)
        {

        }

        public async Task<Juro> GetTaxaJuros()
        {
            return await Task.FromResult(new Juro(0.01m)).ConfigureAwait(false);
        }
    }
}
