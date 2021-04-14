using MarsRover.Infrastructure.Mediator.Interfaces;
using System.Threading.Tasks;

namespace MarsRover.Infrastructure.Handler
{
    public interface INotificationHandler<in TNotification> where TNotification : INotification
    {
        Task Handle(TNotification notification);
    }
}
