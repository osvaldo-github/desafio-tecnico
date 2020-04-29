namespace Application.UseCases
{
    using System;
    using System.Threading.Tasks;
    using Application.Boundaries.CalculaJuros;
    using Domain.Financeiro;
    using Domain.Financeiro.ValueObjects;

    public sealed class CalculaJurosUseCase : IUseCase
    {
        private readonly IOutputPort _outputPort;
        private readonly IFinanceiroIntegration _financeiroIntegration;

        public CalculaJurosUseCase(
            IOutputPort outputPort,
            IFinanceiroIntegration financeiroIntegration)
        {
            this._outputPort = outputPort;
            this._financeiroIntegration = financeiroIntegration;
        }

        public async Task Execute(CalculaJurosInput input)
        {
            if (input is null)
            {
                this._outputPort.WriteError(Messages.InputIsNull);
                return;
            }

            var juro = await _financeiroIntegration.GetTaxaJuros().ConfigureAwait(false);

            decimal valor = input.ValorInicial.ToDecimal();

            for (int n = 0; n < input.Meses.ToInt(); n++)
            {
                valor = (valor * (1 + juro.ToDecimal()));
            }

            Resultado resultado = new Resultado(Convert.ToDecimal(Math.Truncate(100 * valor) / 100));

            this.BuildOutput(resultado);
        }

        private void BuildOutput(Resultado resultado)
        {
            var output = new CalculaJurosOutput(resultado);
            this._outputPort.Standard(output);
        }
    }
}