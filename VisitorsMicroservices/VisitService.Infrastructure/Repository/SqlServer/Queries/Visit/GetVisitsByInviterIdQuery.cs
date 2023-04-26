using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Entity.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitsByInviterIdQuery: IGetVisitsByInviterIdQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetVisitsByInviterIdQuery> _logger;
    public GetVisitsByInviterIdQuery(ApplicationDBContext dbContext, ILogger<GetVisitsByInviterIdQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId)
    {

        try
        {
            var visits = await _dbContext.VISIT_GENERAL_INFO.Where(x => x.INVITER_ID == inviterId && x.DELETED == false).ToListAsync();

            var result = new DataListResultModel<VisitGeneralInfo>
            {
                Success = true,
                DataResults = visits,
                ErrorMessage = "",
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
