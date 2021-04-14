using MarsRover.Infrastructure.Geography;
using MarsRover.Infrastructure.Geography.Interfaces;
using MarsRover.Infrastructure.Vehicle;

namespace MarsRover.Infrastructure.Mediator.Interfaces
{
    public interface IMediator<TVehicle> : ISender<TVehicle>, IPublisher where TVehicle:IVehicle
    {
        public IPlateau Plateau { get; set; }
    }
   
}
