namespace ComponentTests.V1
{
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public sealed class FinanceiroTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _factory;

        public FinanceiroTests(CustomWebApplicationFactory factory)
        {
            this._factory = factory;
        }

        [Fact]
        public async Task GetTaxaJuros()
        {
            var client = this._factory.CreateClient();

            var response = await client.GetAsync("api/v1/Api1/taxaJuros")
                .ConfigureAwait(true);

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            Assert.Contains("juro", responseString);
            JObject resultado = JsonConvert.DeserializeObject<JObject>(responseString);

            decimal valor = resultado["juro"].Value<decimal>();

            Assert.Equal(0.01m, valor);
        }

        [Fact]
        public async Task CalculaJuros()
        {
            var client = this._factory.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            var response = await client.GetAsync("api/v1/Api2/calculajuros?valorinicial=100&meses=5")
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            Assert.Contains("resultado", responseString);
            JObject resultado = JsonConvert.DeserializeObject<JObject>(responseString);

            decimal valor = resultado["resultado"].Value<decimal>();

            Assert.Equal(105.1m, valor);
        }

        [Fact]
        public async Task ShowMeTheCode()
        {
            var client = this._factory.CreateClient();

            var response = await client.GetAsync("api/v1/Api2/showmethecode")
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string responseString = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            Assert.Contains("linkGitHubProject", responseString);
            JObject resultado = JsonConvert.DeserializeObject<JObject>(responseString);

            string valor = resultado["linkGitHubProject"].Value<string>();

            Assert.Equal("https://github.com/osvaldo-github/desafio-tecnico", valor);
        }
    }
}
