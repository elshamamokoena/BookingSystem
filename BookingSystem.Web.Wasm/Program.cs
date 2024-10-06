using BookingSystem.Shared.Contracts;
using BookingSystem.Web.Wasm.Components;
using BookingSystem.Shared.Services;
using Blazored.LocalStorage;
using BookingSystem.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using BookingSystem.Shared.Auth;
using BookingSystem.Shared.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using BookingSystem.AuthorizationPolicies;
using IdentityModel;

const string entraIdScheme = "EntraIdOpenIdConnect";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingAuthenticationStateProvider>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddOpenIdConnectAccessTokenManagement()
      .AddBlazorServerAccessTokenManagement<CustomServerSideTokenStore>();

builder.Services.AddTransient<CustomTokenStorageOidcEvents>();

builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri("https://localhost:7171"),
    
});

//builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7171"))
    .AddUserAccessTokenHandler();
    //.AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = entraIdScheme;
}).AddOpenIdConnect(entraIdScheme, options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Scope.Add(OpenIdConnectScope.OpenIdProfile);
    options.Scope.Add("api://dea7c32d-3f8f-4ecc-b959-fd1938a7f8f6/FullAccess");
    options.Scope.Add("offline_access");
    options.MapInboundClaims = false;
    options.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
    options.TokenValidationParameters.RoleClaimType = "roles";
    options.SaveTokens = true;
    options.EventsType = typeof(CustomTokenStorageOidcEvents);
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.AccessDeniedPath = "/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.IsManager,Policies.ManagerPolicy());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEventDataService, EventDataService>();
builder.Services.AddScoped<IConferenceRoomService, ConferenceRoomService>();
builder.Services.AddScoped<IBookingDataService, BookingDataService>();
builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
builder.Services.AddScoped<IStockEnquiryDataService, StockEnquiryDataService>();
builder.Services.AddScoped<IConsumableDataService, ConsumableDataService>();
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
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(BookingSystem.Shared._Imports).Assembly);



app.MapGet("/login", (string? returnUrl, HttpContext httpContext) =>
{
    // ensure the returnUrl is valid & safe.  
    returnUrl = ValidateUri(httpContext, returnUrl);

    return TypedResults.Challenge(
                 new AuthenticationProperties
                 { RedirectUri = returnUrl });
}).AllowAnonymous();


app.MapPost("/logout", (string? returnUrl, HttpContext httpContext) =>
{
    returnUrl = ValidateUri(httpContext, returnUrl);
    return TypedResults.SignOut(
        new AuthenticationProperties
        { RedirectUri = returnUrl },
            [CookieAuthenticationDefaults.AuthenticationScheme, entraIdScheme]);
});
app.Run();

public partial class Program
{
    private static string ValidateUri(HttpContext httpContext, string? uri)
    {
        string basePath = string.IsNullOrEmpty(httpContext.Request.PathBase)
                ? "/" : httpContext.Request.PathBase;

        if (string.IsNullOrEmpty(uri))
        {
            return basePath;
        }
        else if (!Uri.IsWellFormedUriString(uri, UriKind.Relative))
        {
            return new Uri(uri, UriKind.Absolute).PathAndQuery;
        }
        else if (uri[0] != '/')
        {
            return $"{basePath}{uri}";
        }

        return uri;
    }
}