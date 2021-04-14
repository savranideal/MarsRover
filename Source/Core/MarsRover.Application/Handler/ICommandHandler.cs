using MarsRover.Infrastructure.Command;

namespace MarsRover.Infrastructure.Handler
{
    public interface ICommandHandler<TCommand, TVehicle> where TCommand : ICommand
    {
    }
}
