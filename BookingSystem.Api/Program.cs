using BookingSystem.Api;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Booking system API starting");

//initialize web application builder
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(
      (context, services, configuration) => configuration
          .ReadFrom.Configuration(context.Configuration)
          .ReadFrom.Services(services)
          .Enrich.FromLogContext()
          .WriteTo.Console(),
      true
  );

var app= builder
    .ConfigureServices()
    .ConfigurePipeline();

app.UseSerilogRequestLogging();
//await app.ResetDatabaseAsync();


app.Run();

//The Program class is split into two files: Program.cs and Startup.cs
//When the application is compled, the final type is created by merging the two files.
//Ref: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods
public partial class Program { }