﻿using Eventmi.Infrastructure.Data;
using Eventmi.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

static class EventmiServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EventmiDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IRepository, Repository>();
        
        return services;
    }
}
