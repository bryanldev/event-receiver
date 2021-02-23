using Domain.Entities.SensorEventAggregate;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class RepositoryConfig
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ISensorEventRepository, SensorEventRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }

    }
}