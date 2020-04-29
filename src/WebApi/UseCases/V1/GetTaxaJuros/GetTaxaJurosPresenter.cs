namespace WebApi.UseCases.V1.GetTaxaJuros
{
    using Application.Boundaries.GetTaxaJuros;
    using Microsoft.AspNetCore.Mvc;

    public sealed class GetTaxaJurosPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            this.ViewModel = new NotFoundObjectResult(message);
        }

        public void Standard(GetTaxaJurosOutput getTaxaJurosOutput)
        {
            var getTaxaJurosResponse = new GetTaxaJurosResponse(
                getTaxaJurosOutput.Juro);

            this.ViewModel = new OkObjectResult(getTaxaJurosResponse);
        }

        public void WriteError(string message)
        {
            this.ViewModel = new BadRequestObjectResult(message);
        }
    }
}
