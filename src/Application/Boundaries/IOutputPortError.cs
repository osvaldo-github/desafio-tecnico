namespace Application.Boundaries
{
    public interface IOutputPortError
    {
        void WriteError(string message);
    }
}