using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitsQuery : IGetVisitsQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetVisitsQuery> _logger;

    public GetVisitsQuery(ApplicationDBContext dbContext, ILogger<GetVisitsQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync()
    {
        try
        {
            var visits = await _dbContext.VISIT_GENERAL_INFO.Where(x => x.DELETED == false).ToListAsync();

            var result = new DataListResultModel<VisitGeneralInfo>
            {
                Success = true,
                DataResults = visits,
                ErrorMessage = ""
            };

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ErrorMessage}", ex.Message);

            var result = new DataListResultModel<VisitGeneralInfo>
            {
                Success = false,
                DataResults = new List<VisitGeneralInfo>(),
                ErrorMessage = "Get visits failed"
            };

            return result;
        }
    }
}
