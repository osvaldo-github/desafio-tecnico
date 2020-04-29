namespace UnitTests.UseCaseTests.CalculaJuros
{
    using Xunit;

    internal sealed class NegativeDataSetup : TheoryData<decimal, int>
    {
        public NegativeDataSetup()
        {
            this.Add(-100m, 5);
            this.Add(100m, -5);
        }
    }
}
