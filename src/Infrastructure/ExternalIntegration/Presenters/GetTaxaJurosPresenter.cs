namespace Infrastructure.ExternalIntegration.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.GetTaxaJuros;

    public sealed class GetTaxaJurosPresenter : IOutputPort
    {
        public GetTaxaJurosPresenter()
        {
            this.GetTaxaJuros = new Collection<GetTaxaJurosOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<GetTaxaJurosOutput> GetTaxaJuros { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(GetTaxaJurosOutput output)
        {
            this.GetTaxaJuros.Add(output);
        }

        public void NotFound(string message)
        {
            this.NotFounds.Add(message);
        }

        public void WriteError(string message)
        {
            this.Errors.Add(message);
        }
    }
}
