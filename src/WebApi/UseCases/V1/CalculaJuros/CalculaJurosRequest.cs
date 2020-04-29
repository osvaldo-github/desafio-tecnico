namespace WebApi.UseCases.V1.CalculaJuros
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     The request to CalculaJuros.
    /// </summary>
    public sealed class CalculaJurosRequest
    {
        /// <summary>
        ///     Gets or sets the amount to ValorInicial.
        /// </summary>
        [Required]
        [FromQuery(Name = "valorinicial")]
        public decimal ValorInicial { get; set; } = .0M;

        /// <summary>
        ///     Gets or sets the amount to Meses.
        /// </summary>
        [Required]
        [FromQuery(Name = "meses")]
        public int Meses { get; set; } = 0;
    }
}
