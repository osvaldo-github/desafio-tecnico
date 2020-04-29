namespace WebApi.UseCases.V1.CalculaJuros
{
    using System.ComponentModel.DataAnnotations;
    using Domain.Financeiro.ValueObjects;

    /// <summary>
    ///     Calcula Juros Response
    /// </summary>
    public sealed class CalculaJurosResponse
    {
        public CalculaJurosResponse(Resultado resultado)
        {
            this.Resultado = resultado.ToDecimal();
        }

        /// <summary>
        ///     Gets Resultado.
        /// </summary>
        [Required]
        public decimal Resultado { get; }
    }
}
