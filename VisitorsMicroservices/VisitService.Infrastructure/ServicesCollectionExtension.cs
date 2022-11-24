using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VisitService.Application.Common.Interfaces;
using VisitService.Application.Configuration;
using VisitService.Application.Repositories;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Application.Services;
using VisitService.Application.Services.Interfaces;
using VisitService.Infrastructure.Persistence;
using VisitService.Infrastructure.Repository.SqlServer.Queries.Destination;
using VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

namespace VisitService.Infrastructure;

public static class ServicesCollectionExtension
{
    public static void AddVisitsServiceInfrastructureServices(this IServiceCollection services, Settings settings)
    {
        services.AddSingleton(settings);

        services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(settings.VisitsDBConnectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)), ServiceLifetime.Transient);

        services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());

        services.AddScoped<IVisitsService, VisitsService>();
        services.AddScoped<IVisitsRepository, VisitsRepository>();

        services.AddScoped<IGetVisitsQuery, GetVisitsQuery>();
        services.AddScoped<IGetVisitByIdQuery, GetVisitByIdQuery>();
        services.AddScoped<IGetVisitsByInviterIdQuery, GetVisitsByInviterIdQuery>();

        services.AddScoped<IGetVisitTypesQuery, GetVisitTypesQuery>();
        services.AddScoped<IGetVisitPurposesQuery, GetVisitPurposesQuery>();
        services.AddScoped<IGetCampusesQuery, GetCampusesQuery>();
        services.AddScoped<IGetBuildingsQuery, GetBuildingsQuery>();
        services.AddScoped<IGetFloorsQuery, GetFloorsQuery>();

    }
}
