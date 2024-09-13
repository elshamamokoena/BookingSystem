using Blazored.LocalStorage;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Services;
using BookingSystem.Web.App;
using BookingSystem.Web.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7171/"));
builder.Services.AddScoped<IBookingDataService, BookingDataService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();


var appbuilder =  builder.Build();

await appbuilder.RunAsync();

