namespace Application.Boundaries.CalculaJuros
{
    using Domain.Financeiro.ValueObjects;

    public sealed class CalculaJurosOutput
    {
        public CalculaJurosOutput(Resultado resultado)
        {
            this.Resultado = resultado;
        }

        public Resultado Resultado { get; }
    }
}