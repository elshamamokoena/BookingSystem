using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Persistence.DbContexts;
using BookingSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence
{
    //This is the Dependency Injection class for the Persistence Layer
    // This class is responsible for registering the services in the Persistence Layer
    // The services registered in this class are used in the Application Layer
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersitenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingSystemDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("BookingSystemDb"));
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IConferenceRoomRepository, ConferenceRoomRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAmenityRepository, AmenityRepository>();
            services.AddScoped<IConsumableRepository, ConsumableRepository>();
            services.AddScoped<IBookingRepository, BookingRepository >();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockEnquiryRepository, StockEnquiryRepository>();
            return services;
        }
    }
}
