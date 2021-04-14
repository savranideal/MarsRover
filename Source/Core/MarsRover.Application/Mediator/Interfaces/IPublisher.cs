using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Infrastructure.Mediator.Interfaces
{
    public interface IPublisher
    {
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification;
    }
}
