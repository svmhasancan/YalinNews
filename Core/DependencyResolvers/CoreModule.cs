using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Buraya ileride eklenecek diğer core servisler gelecek
            // Örneğin:
            // serviceCollection.AddMemoryCache();
            // serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            // serviceCollection.AddSingleton<ILogService, LogManager>();
        }
    }
} 