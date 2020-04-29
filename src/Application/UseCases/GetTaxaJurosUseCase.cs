namespace Application.UseCases
{
    using System.Threading.Tasks;
    using Application.Boundaries.GetTaxaJuros;
    using Domain.Financeiro.ValueObjects;

    public sealed class GetTaxaJurosUseCase : IUseCase
    {
        private readonly IOutputPort _outputPort;
        private const decimal JURO = 0.01m;

        public GetTaxaJurosUseCase(
            IOutputPort outputPort)
        {
            this._outputPort = outputPort;
        }

        public async Task Execute(GetTaxaJurosInput input)
        {
            if (input is null)
            {
                this._outputPort.WriteError(Messages.InputIsNull);
                return;
            }

            // Aqui busca dados na camada de Infrastructure.
            // No entanto foi solicitado para retornar o valor fixo de 0.01 de Juros.

            Juro juro = new Juro(JURO);

            this.BuildOutput(juro);
        }

        private void BuildOutput(Juro juro)
        {
            var output = new GetTaxaJurosOutput(juro);
            this._outputPort.Standard(output);
        }
    }
}