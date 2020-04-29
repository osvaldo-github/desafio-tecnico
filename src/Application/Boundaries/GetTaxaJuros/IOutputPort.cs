namespace Application.Boundaries.GetTaxaJuros
{
    public interface IOutputPort
        : IOutputPortStandard<GetTaxaJurosOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
