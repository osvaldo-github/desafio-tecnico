namespace Application.Boundaries.GetTaxaJuros
{
    using Domain.Financeiro.ValueObjects;

    public sealed class GetTaxaJurosOutput
    {
        public GetTaxaJurosOutput(Juro juro)
        {
            this.Juro = juro;
        }

        public Juro Juro { get; }
    }
}