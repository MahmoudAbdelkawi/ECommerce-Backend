using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Core
{
    public static class CoreCollections
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}