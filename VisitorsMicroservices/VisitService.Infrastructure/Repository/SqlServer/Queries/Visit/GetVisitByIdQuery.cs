using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitByIdQuery : IGetVisitByIdQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetVisitsQuery> _logger;

    public GetVisitByIdQuery(ApplicationDBContext dbContext, ILogger<GetVisitsQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<VisitResultModel> GetVisitByIdAsync(int visitId)
	{
        try
        {
            var visit = await _dbContext.VISIT_GENERAL_INFO.Where(x => x.ID == visitId).FirstOrDefaultAsync();

            var result = new VisitResultModel();

            if (visit == null)
            {
                result.Success = false;
                result.Visit = new VisitGeneralInfo();
                result.ErrorMessage = $"Visit with ID {visitId} not exists";
            }
            else
            {
                result.Success = true;
                result.Visit = visit;
                result.ErrorMessage = "";
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ErrorMessage}", ex.Message);

            var result = new VisitResultModel
            {
                Success = false,
                Visit = new VisitGeneralInfo(),
                ErrorMessage = "Get visit failed"
            };

            return result;
        }
    }
}
