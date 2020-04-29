namespace UnitTests.UseCaseTests.GetTaxaJuros
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.GetTaxaJuros;
    using Application.UseCases;
    using Infrastructure.ExternalIntegration.Presenters;
    using TestFixtures;
    using Xunit;

    public sealed class GetTaxaJurosTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public GetTaxaJurosTests(StandardFixture fixture)
        {
            this._fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task GetTaxaJuros(decimal resultado)
        {
            var presenter = new GetTaxaJurosPresenter();
            var useCase = new GetTaxaJurosUseCase(
                presenter);

            await useCase.Execute(
                new GetTaxaJurosInput());

            var output = presenter.GetTaxaJuros.Last();
            Assert.Equal(resultado, output.Juro.ToDecimal());
        }
    }
}
