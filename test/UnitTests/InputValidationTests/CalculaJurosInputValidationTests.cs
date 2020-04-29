namespace UnitTests.InputValidationTests
{
    using System;
    using Application.Boundaries.CalculaJuros;
    using Domain.Financeiro.ValueObjects;
    using Xunit;

    public sealed class CalculaJurosInputValidationTests
    {
        [Fact]
        public void GivenNegativeValorInicial_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<ValorInicialShouldBePositiveException>(
                () => new CalculaJurosInput(
                    new ValorInicial(-1),
                    new Meses(1)));
            Assert.Contains("Valor Inicial", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GivenNegativeMeses_InputNotCreated_ThrowsInputValidationException()
        {
            var actualEx = Assert.Throws<MesesShouldBePositiveException>(
                () => new CalculaJurosInput(
                    new ValorInicial(1),
                    new Meses(-1)));
            Assert.Contains("Meses", actualEx.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void GivenValidData_InputCreated()
        {
            var actual = new CalculaJurosInput(
                new ValorInicial(1),
                new Meses(1));
            Assert.NotNull(actual);
        }
    }
}
