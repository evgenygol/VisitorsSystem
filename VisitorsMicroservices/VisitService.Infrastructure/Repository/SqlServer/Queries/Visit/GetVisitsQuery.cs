using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;
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

    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsAsync()
    {
        try
        {
            var visits = await _dbContext.VISIT_GENERAL_INFO.Where(x => x.DELETED == false).ToListAsync();

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
            _logger.LogError(ex, "{GetVisits}", ex.Message);

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
