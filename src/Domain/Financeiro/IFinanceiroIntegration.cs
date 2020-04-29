namespace Domain.Financeiro
{
    using System.Threading.Tasks;
    using ValueObjects;

    public interface IFinanceiroIntegration
    {
        Task<Juro> GetTaxaJuros();
    }
}