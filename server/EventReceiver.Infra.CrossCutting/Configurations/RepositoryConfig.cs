using EventReceiver.Domain.Interfaces;
using EventReceiver.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace EventReceiver.Infra.CrossCutting.Configurations
{
    public static class RepositoryConfig
    {
        public static void AddRepository(this IServiceCollection services) =>
            services.AddScoped<IEventRepository, EventRepository>();
    }
}