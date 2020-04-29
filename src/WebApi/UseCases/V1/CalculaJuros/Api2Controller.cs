namespace WebApi.UseCases.V1.CalculaJuros
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Application.Boundaries.CalculaJuros;
    using Domain.Financeiro.ValueObjects;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class Api2Controller : ControllerBase
    {
        /// <summary>
        ///     Calcula Juros Compostos
        /// </summary>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [AllowAnonymous]
        [HttpGet("calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculaJurosResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculaJuros(
            [FromServices] IMediator mediator,
            [FromServices] CalculaJurosPresenter presenter,
            [FromQuery] [Required] CalculaJurosRequest request)
        {
            var input = new CalculaJurosInput(
                new ValorInicial(request.ValorInicial),
                new Meses(request.Meses));

            await mediator.PublishAsync(input)
                .ConfigureAwait(false);
            return presenter.ViewModel;
        }
    }
}
