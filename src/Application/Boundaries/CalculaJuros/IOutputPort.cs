namespace Application.Boundaries.CalculaJuros
{
    public interface IOutputPort
        : IOutputPortStandard<CalculaJurosOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
