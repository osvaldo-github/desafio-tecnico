namespace Application.Boundaries
{
    using System.Threading.Tasks;

    public interface IUseCase<in TUseCaseInput>
    {
        Task Execute(TUseCaseInput input);
    }
}