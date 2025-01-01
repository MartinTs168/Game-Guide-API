using GameGuide.Core.Contracts;
using GameGuide.Core.Services;
using GameGuide.Data;
using GameGuide.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        
        services.AddScoped<IRepository, Repository>();
        
        
        return services;
    }

    public static IServiceCollection AttachService(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
        
        return services;
    }
}