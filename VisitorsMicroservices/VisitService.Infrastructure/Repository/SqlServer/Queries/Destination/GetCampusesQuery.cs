using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Domain.Entity.Destination;
using VisitService.Infrastructure.Persistence;
using VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Destination;

internal class GetCampusesQuery : IGetCampusesQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetCampusesQuery> _logger;

    public GetCampusesQuery(ApplicationDBContext dbContext, ILogger<GetCampusesQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<DataListResultModel<Campus>> GetCampusesAsync()
    {
        try
        {
            var campuses = await _dbContext.CAMPUSES.ToListAsync();

            var result = new DataListResultModel<Campus>
            {
                Success = true,
                DataResults = campuses,
                ErrorMessage = ""
            };

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{GetCampuses}", ex.Message);

            var result = new DataListResultModel<Campus>
            {
                Success = false,
                DataResults = new List<Campus>(),
                ErrorMessage = "Get campuses failed"
            };

            return result;
        }
    }
}
