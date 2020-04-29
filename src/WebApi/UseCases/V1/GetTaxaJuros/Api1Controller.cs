namespace WebApi.UseCases.V1.GetTaxaJuros
{
    using System.Threading.Tasks;
    using Application.Boundaries.GetTaxaJuros;
    using FluentMediator;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class Api1Controller : ControllerBase
    {
        /// <summary>
        ///     Retorna a taxa de juros
        /// </summary>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [AllowAnonymous]
        [HttpGet("taxaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTaxaJurosResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTaxaJuros(
            [FromServices] IMediator mediator,
            [FromServices] GetTaxaJurosPresenter presenter)
        {
            var input = new GetTaxaJurosInput();
            await mediator.PublishAsync(input)
                .ConfigureAwait(false);
            return presenter.ViewModel;
        }
    }
}

