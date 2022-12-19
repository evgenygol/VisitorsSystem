using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitPurposesQuery : IGetVisitPurposesQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetVisitPurposesQuery> _logger;

    public GetVisitPurposesQuery(ApplicationDBContext dbContext, ILogger<GetVisitPurposesQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<DataListResultModel<VisitPurpose>> GetVisitPurposesAsync()
    {
        try
        {
            var visitPurposes = await _dbContext.VISIT_PURPOSES.ToListAsync();

            var result = new DataListResultModel<VisitPurpose>
            {
                Success = true,
                DataResults = visitPurposes,
                ErrorMessage = ""
            };

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ErrorMessage}", ex.Message);

            var result = new DataListResultModel<VisitPurpose>
            {
                Success = false,
                DataResults = new List<VisitPurpose>(),
                ErrorMessage = "Get visit purposes failed"
            };

            return result;
        }
    }
}
