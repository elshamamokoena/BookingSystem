using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        //register services used in the application layer
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // register automapper with all the profiles created in the application layer
            // this will allow us to map between domain entities,dtos,vm and responses
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //mediatr is a library that helps us implement the mediator pattern
            services.AddMediatR(o=>
            o.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            return services;
        }
    }
}
