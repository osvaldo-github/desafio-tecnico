namespace WebApi.UseCases.V1.ShowMeTheCode
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class Api2Controller : ControllerBase
    {
        /// <summary>
        ///     Retorna o link do projeto no GitHub
        /// </summary>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [AllowAnonymous]
        [HttpGet("showmethecode")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ShowMeTheCodeResponse))]
        public async Task<IActionResult> ShowMeTheCode()
        {
            return new OkObjectResult(new ShowMeTheCodeResponse());
        }
    }
}
