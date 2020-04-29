namespace Infrastructure.ExternalIntegration.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.CalculaJuros;

    public sealed class CalculaJurosPresenter : IOutputPort
    {
        public CalculaJurosPresenter()
        {
            this.CalculaJuros = new Collection<CalculaJurosOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<CalculaJurosOutput> CalculaJuros { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(CalculaJurosOutput output)
        {
            this.CalculaJuros.Add(output);
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
