using Blazored.LocalStorage;
using BookingSystem.Shared;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Helpers;
using BookingSystem.Shared.Services;
using Microsoft.Extensions.Logging;

namespace BookingSystem.Android.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            // for dev purposes only
            var devSslHelper = new DevHttpsConnectionHelper(sslPort: 7171);
            var http = devSslHelper.HttpClient;
            http.BaseAddress = new Uri(devSslHelper.DevServerRootUrl);
            builder.Services.AddScoped<IClient>(sp => new Client(http));

            //builder.Services.AddHttpClient<IClient, Client>(client=>client.BaseAddress= new Uri());


            builder.Services.AddScoped<IEventDataService, EventDataService>();
            builder.Services.AddScoped<IConferenceRoomService, ConferenceRoomService>();
            builder.Services.AddScoped<IBookingDataService, BookingDataService>();
            builder.Services.AddScoped<IStockDataService, StockDataService>();
            builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
            builder.Services.AddScoped<IStockEnquiryDataService, StockEnquiryDataService>();
            builder.Services.AddScoped<IConsumableDataService, ConsumableDataService>();
            builder.Services.AddScoped<ICartDataService, CartDataService>();
            builder.Services.AddScoped<IAmenityDataService, AmenityDataService>();
            builder.Services.AddScoped<IStockDataService, StockDataService>();
            builder.Services.AddScoped<IJsInterop, JsInterop>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddBlazoredLocalStorage();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
