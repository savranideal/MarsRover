using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Infrastructure.Mediator.Interfaces
{
    public interface IPublisher
    {
        void Publish<TNotification>(TNotification notification) where TNotification : INotification;
    }
}
