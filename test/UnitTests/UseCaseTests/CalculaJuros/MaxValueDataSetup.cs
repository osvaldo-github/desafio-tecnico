namespace UnitTests.UseCaseTests.CalculaJuros
{
    using Xunit;

    internal sealed class MaxValueDataSetup : TheoryData<decimal, int>
    {
        public MaxValueDataSetup()
        {
            this.Add(10000000000000.01m, 1);
            this.Add(10000000000000m, 1201);
        }
    }
}
