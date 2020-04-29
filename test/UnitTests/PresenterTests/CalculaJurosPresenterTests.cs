namespace UnitTests.PresenterTests
{
    using System.Net;
    using Application.Boundaries.CalculaJuros;
    using Domain.Financeiro.ValueObjects;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UseCases.V1.CalculaJuros;
    using Xunit;

    public sealed class CalculaJurosPresenterTests
    {
        [Fact]
        public void GivenValidData_Handle_WritesOkObjectResult()
        {
            Resultado resultado = new Resultado(105.1m);

            var output = new CalculaJurosOutput(resultado);

            var presenter = new CalculaJurosPresenter();
            presenter.Standard(output);

            var actual = Assert.IsType<OkObjectResult>(presenter.ViewModel);
            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);

            var actualValue = (CalculaJurosResponse)actual.Value;
            Assert.Equal(resultado.ToDecimal(), actualValue.Resultado);
        }
    }
}
