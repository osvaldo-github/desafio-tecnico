namespace UnitTests.UseCaseTests.CalculaJuros
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<decimal, int, decimal>
    {
        public PositiveDataSetup()
        {
            this.Add(0m, 0, 0m);
            this.Add(1m, 1, 1.01m);
            this.Add(100m, 5, 105.1m);
            this.Add(234234m, 1045, 7682198731.02m);
        }
    }
}
