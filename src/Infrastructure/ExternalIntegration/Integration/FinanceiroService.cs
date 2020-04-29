namespace Infrastructure.ExternalIntegration.Integration
{
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Domain.Financeiro;
    using Domain.Financeiro.ValueObjects;

    public sealed class FinanceiroService : IFinanceiroIntegration
    {
        HttpClient _httpClient;

        public FinanceiroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Juro> GetTaxaJuros()
        {
            string apiResponse;

            using (var httpClient = _httpClient)
            {
                using (var response = await httpClient.GetAsync("/api/v1/Api1/taxaJuros").ConfigureAwait(false))
                {
                    apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new FinanceiroExternalIntegrationException("Ocorreu um erro ao tentar obter a taxa de juros");
                    }
                }
            }

            JsonResponse jsonResponse = JsonSerializer.Deserialize<JsonResponse>(apiResponse);

            return await Task.FromResult(new Juro(jsonResponse.Juro)).ConfigureAwait(false);
        }
    }

    public class JsonResponse
    {
        [JsonPropertyName("juro")]
        public decimal Juro { get; set; }
    }
}
