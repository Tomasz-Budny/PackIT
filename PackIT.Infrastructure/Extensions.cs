﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF;
using PackIT.Infrastructure.Services;
using PackIT.Shared.Queries;

namespace PackIT.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IWeatherService, DumbWeatherService>();
            //services.AddPostgres(configuration);
            services.AddSqlServer(configuration);
            services.AddQueries();
            return services;
        }
    }
}

