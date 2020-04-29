namespace UnitTests.UseCaseTests.CalculaJuros
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Boundaries.CalculaJuros;
    using Application.UseCases;
    using Domain.Financeiro.ValueObjects;
    using Infrastructure.ExternalIntegration.Presenters;
    using TestFixtures;
    using Xunit;

    public sealed class CalculaJurosTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public CalculaJurosTests(StandardFixture fixture)
        {
            this._fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task CalculaJuros(decimal valorInicial, int meses, decimal resultado)
        {
            var presenter = new CalculaJurosPresenter();
            var useCase = new CalculaJurosUseCase(
                presenter,
                _fixture.FinanceiroService);

            await useCase.Execute(
                new CalculaJurosInput(
                    new ValorInicial(valorInicial),
                    new Meses(meses)));

            var output = presenter.CalculaJuros.Last();
            Assert.Equal(resultado, output.Resultado.ToDecimal());
        }

        [Theory]
        [ClassData(typeof(NegativeDataSetup))]
        public async Task CalculaJuros_ShouldNot_Calculate_WhenNegative(decimal valorInicial, int meses)
        {
            var presenter = new CalculaJurosPresenter();
            var useCase = new CalculaJurosUseCase(
                presenter,
                _fixture.FinanceiroService);

            if (valorInicial < 0)
            {
                await Assert.ThrowsAsync<ValorInicialShouldBePositiveException>(() =>
                useCase.Execute(new CalculaJurosInput(
                    new ValorInicial(valorInicial),
                    new Meses(meses))));
            }

            if (meses < 0)
            {
                await Assert.ThrowsAsync<MesesShouldBePositiveException>(() =>
                useCase.Execute(new CalculaJurosInput(
                    new ValorInicial(valorInicial),
                    new Meses(meses))));
            }
        }

        [Theory]
        [ClassData(typeof(NegativeDataSetup))]
        public async Task CalculaJuros_ShouldNot_Calculate_WhenMaxValue(decimal valorInicial, int meses)
        {
            var presenter = new CalculaJurosPresenter();
            var useCase = new CalculaJurosUseCase(
                presenter,
                _fixture.FinanceiroService);

            if (valorInicial > 10000000000000m)
            {
                await Assert.ThrowsAsync<ValorInicialMaxValueException>(() =>
                useCase.Execute(new CalculaJurosInput(
                    new ValorInicial(valorInicial),
                    new Meses(meses))));
            }

            if (meses > 1200)
            {
                await Assert.ThrowsAsync<MesesMaxValueException>(() =>
                useCase.Execute(new CalculaJurosInput(
                    new ValorInicial(valorInicial),
                    new Meses(meses))));
            }
        }
    }
}
