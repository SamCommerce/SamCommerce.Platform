using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SamCommerce.Platform.Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Caching
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();

            var redisConnectionString = configuration.GetConnectionString("RedisConnectionString");

            services.AddSingleton<IPlatformMemoryCache, PlatformMemoryCache>();

            return services;
        }
    }
}
