using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitsFilterByDatesQuery : IGetVisitsFilterByDatesQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetVisitsFilterByDatesQuery> _logger;

    public GetVisitsFilterByDatesQuery(ApplicationDBContext dbContext, ILogger<GetVisitsFilterByDatesQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            var visits = await _dbContext.VISIT_GENERAL_INFO.Where(x => x.VISIT_START_DATE >= startDate && x.VISIT_END_DATE <= endDate && x.DELETED == false).ToListAsync();

            var result = new DataListResultModel<VisitGeneralInfoDTO>
            {
                Success = true,
                ErrorMessage = ""
            };

            foreach (var visit in visits)
            {
                var visitDTO = new VisitGeneralInfoDTO();
                visitDTO.VisitGeneralInfo = visit;

                var visitDestinations = await _dbContext.VISIT_DESTINATION_INFO.Where(x => x.VISIT_ID == visit.ID).ToListAsync();
                visitDTO.VisitDestinationInfo = visitDestinations;
                result.DataResults.Add(visitDTO);
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{GetVisitsFilterByDates}", ex.Message);

            var result = new DataListResultModel<VisitGeneralInfoDTO>
            {
                Success = false,
                DataResults = new List<VisitGeneralInfoDTO>(),
                ErrorMessage = "Get visits failed"
            };

            return result;
        }
    }
}
