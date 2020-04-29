namespace UnitTests.PresenterTests
{
    using System.Net;
    using Application.Boundaries.GetTaxaJuros;
    using Domain.Financeiro.ValueObjects;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.UseCases.V1.GetTaxaJuros;
    using Xunit;

    public sealed class GetTaxaJurosPresenterTests
    {
        [Fact]
        public void GivenValidData_Handle_WritesOkObjectResult()
        {
            Juro juro = new Juro(0.01m);

            var output = new GetTaxaJurosOutput(juro);

            var presenter = new GetTaxaJurosPresenter();
            presenter.Standard(output);

            var actual = Assert.IsType<OkObjectResult>(presenter.ViewModel);
            Assert.Equal((int)HttpStatusCode.OK, actual.StatusCode);

            var actualValue = (GetTaxaJurosResponse)actual.Value;
            Assert.Equal(juro.ToDecimal(), actualValue.Juro);
        }
    }
}
