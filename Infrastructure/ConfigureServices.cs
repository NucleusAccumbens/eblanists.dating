﻿using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("InDeveloping"))
        {
            services.AddDbContext<TelegramBotDatingAppDbCotext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        else
        {

        }

        services.AddScoped<IDatingAppDbContext>(provider => 
        provider.GetRequiredService<TelegramBotDatingAppDbCotext>());

        services.AddTransient<IDateTime, DateTimeService>();

        return services;
    }
}
