using WebChip.Domain.Commands.Contracts;

namespace WebChip.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
