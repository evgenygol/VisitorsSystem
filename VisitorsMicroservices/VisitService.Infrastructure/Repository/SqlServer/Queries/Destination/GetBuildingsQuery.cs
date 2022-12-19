using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Domain.Destination;
using VisitService.Infrastructure.Persistence;
using VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Destination;

internal class GetBuildingsQuery : IGetBuildingsQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetBuildingsQuery> _logger;

    public GetBuildingsQuery(ApplicationDBContext dbContext, ILogger<GetBuildingsQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<DataListResultModel<Building>> GetBuildingsAsync()
    {
        try
        {
            var buildings = await _dbContext.BUILDINGS.ToListAsync();

            var result = new DataListResultModel<Building>
            {
                Success = true,
                DataResults = buildings,
                ErrorMessage = ""
            };

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ErrorMessage}", ex.Message);

            var result = new DataListResultModel<Building>
            {
                Success = false,
                DataResults = new List<Building>(),
                ErrorMessage = "Get buildings failed"
            };

            return result;
        }
    }
}
