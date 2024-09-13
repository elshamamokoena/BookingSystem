using BookingSystem.Shared.Contracts;
using BookingSystem.Web.Wasm.Components;
using BookingSystem.Shared.Services;
using Blazored.LocalStorage;
using BookingSystem.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient<IClient, Client>(client=> client.BaseAddress= new Uri("https://localhost:7171"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEventDataService, EventDataService>();
builder.Services.AddScoped<IConferenceRoomService, ConferenceRoomService>();
builder.Services.AddScoped<IJsInterop, JsInterop>();
builder.Services.AddBlazoredLocalStorage();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(BookingSystem.Shared._Imports).Assembly);

app.Run();
