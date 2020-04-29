namespace UnitTests.UseCaseTests.GetTaxaJuros
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<decimal>
    {
        public PositiveDataSetup()
        {
            this.Add(0.01m);
        }
    }
}
