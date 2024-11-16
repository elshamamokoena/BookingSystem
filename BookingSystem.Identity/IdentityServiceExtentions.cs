using BookingSystem.Application.Contracts.Identity;
using BookingSystem.Application.Models.Authentication;
using BookingSystem.Identity.Models;
using BookingSystem.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingSystem.Identity
{
    public static class IdentityServiceExtentions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddDbContext<BookingSystemIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BookingSystemIdentityConnectionString"), 
                b=>b.MigrationsAssembly(typeof(BookingSystemIdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookingSystemIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };


                options.Events = new JwtBearerEvents
                {
                   OnAuthenticationFailed = ctx =>
                   {
                       ctx.NoResult();
                       ctx.Response.StatusCode = 500;
                       ctx.Response.ContentType = "text/plain";
                       return ctx.Response.WriteAsync(ctx.Exception.ToString());
                   } ,
                    OnChallenge = ctx =>
                    {
                        ctx.HandleResponse();
                        ctx.Response.StatusCode = 401;
                        ctx.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize("401 Not Authorized");
                        return ctx.Response.WriteAsync(result);
                    },
                    OnForbidden = ctx =>
                    {
                        ctx.Response.StatusCode = 403;
                        ctx.Response.ContentType = "application/json";
                        var result = JsonSerializer.Serialize("403 Forbidden");
                        return ctx.Response.WriteAsync(result);
                    },
                };

            });
        }
    }
}
