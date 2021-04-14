using MarsRover.Infrastructure.Mediator;
using MarsRover.Infrastructure.Mediator.Interfaces;
using MarsRover.Infrastructure.Vehicle;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MarsRover.Infrastructure
{
    public static class BootStrapper
    { 
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddTransient<IMediator<IRover>, RoverMediator>();
            return services;
        }
         
    }
}
 