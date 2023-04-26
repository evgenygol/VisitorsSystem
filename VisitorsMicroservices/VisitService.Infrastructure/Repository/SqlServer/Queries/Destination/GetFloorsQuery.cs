using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Domain.Entity.Destination;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Destination;

internal class GetFloorsQuery : IGetFloorsQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetFloorsQuery> _logger;

    public GetFloorsQuery(ApplicationDBContext dbContext, ILogger<GetFloorsQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<DataListResultModel<Floor>> GetFloorsAsync()
    {
        try
        {
            var floors = await _dbContext.FLOORS.ToListAsync();

            var result = new DataListResultModel<Floor>
            {
                Success = true,
                DataResults = floors,
                ErrorMessage = ""
            };

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{GetFloors}", ex.Message);

            var result = new DataListResultModel<Floor>
            {
                Success = false,
                DataResults = new List<Floor>(),
                ErrorMessage = "Get floors failed"
            };

            return result;
        }
    }
}

