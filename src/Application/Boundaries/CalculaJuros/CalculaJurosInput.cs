namespace Application.Boundaries.CalculaJuros
{
    using Domain.Financeiro.ValueObjects;

    public sealed class CalculaJurosInput
    {
        public CalculaJurosInput(
            ValorInicial valorInicial,
            Meses meses)
        {
            this.ValorInicial = valorInicial;
            this.Meses = meses;
        }

        public ValorInicial ValorInicial { get; }

        public Meses Meses { get; }
    }
}
