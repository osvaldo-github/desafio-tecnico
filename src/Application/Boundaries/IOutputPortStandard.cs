namespace Application.Boundaries
{
    public interface IOutputPortStandard<in TUseCaseOutput>
    {
        void Standard(TUseCaseOutput output);
    }
}