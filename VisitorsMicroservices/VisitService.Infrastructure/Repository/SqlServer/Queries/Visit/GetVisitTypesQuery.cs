using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Entity.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

internal class GetVisitTypesQuery : IGetVisitTypesQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetVisitTypesQuery> _logger;

    public GetVisitTypesQuery(ApplicationDBContext dbContext, ILogger<GetVisitTypesQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<DataListResultModel<VisitType>> GetVisitTypesAsync()
    {
        try
        {
            var visitTypes = await _dbContext.VISIT_TYPES.ToListAsync();

            var result = new DataListResultModel<VisitType>
            {
                Success = true,
                DataResults = visitTypes,
                ErrorMessage = ""
            };

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{GetVisitTypes}", ex.Message);

            var result = new DataListResultModel<VisitType>
            {
                Success = false,
                DataResults = new List<VisitType>(),
                ErrorMessage = "Get visit types failed"
            };

            return result;
        }
    }
}
