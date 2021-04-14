using MarsRover.Infrastructure.Geography.Interfaces;
using MarsRover.Infrastructure.Vehicle;

namespace MarsRover.Infrastructure.Mediator.Interfaces
{
    public interface IMediator : ISender, IPublisher
    {
        public IPlateau Plateau { get; set; }
    }

}
