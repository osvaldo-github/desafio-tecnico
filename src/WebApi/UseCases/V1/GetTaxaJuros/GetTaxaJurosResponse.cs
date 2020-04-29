namespace WebApi.UseCases.V1.GetTaxaJuros
{
    using System.ComponentModel.DataAnnotations;
    using Domain.Financeiro.ValueObjects;

    /// <summary>
    ///     Retorna a taxa de juros
    /// </summary>
    public sealed class GetTaxaJurosResponse
    {
        public GetTaxaJurosResponse(Juro juro)
        {
            this.Juro = juro.ToDecimal();
        }

        /// <summary>
        ///     Get Juro
        /// </summary>
        [Required]
        public decimal Juro { get; }
    }
}
