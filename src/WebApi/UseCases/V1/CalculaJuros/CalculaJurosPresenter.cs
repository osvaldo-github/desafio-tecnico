namespace WebApi.UseCases.V1.CalculaJuros
{
    using Application.Boundaries.CalculaJuros;
    using Microsoft.AspNetCore.Mvc;

    public sealed class CalculaJurosPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(CalculaJurosOutput getCalculaJurosOutput)
        {
            var getCalculaJurosResponse = new CalculaJurosResponse(getCalculaJurosOutput.Resultado);

            this.ViewModel = new OkObjectResult(getCalculaJurosResponse);
        }

        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
