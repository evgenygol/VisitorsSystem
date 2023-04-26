using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitByIdQuery : IGetVisitByIdQuery
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<GetVisitByIdQuery> _logger;

    public GetVisitByIdQuery(ApplicationDBContext dbContext, ILogger<GetVisitByIdQuery> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<DataResultModel<VisitGeneralInfoDTO>> GetVisitByIdAsync(int visitId)
	{
        try
        {
            //var visit = await _dbContext.VISIT_GENERAL_INFO.Include("VisitType").Where(x => x.ID == visitId).FirstOrDefaultAsync();
            //var visit = await _dbContext.VISIT_GENERAL_INFO.Include("VisitDestinationInfo").Include("VisitType").Where(x => x.ID == visitId).FirstOrDefaultAsync();

            var visit = await _dbContext.VISIT_GENERAL_INFO.Where(x => x.ID == visitId).FirstOrDefaultAsync();

            var result = new DataResultModel<VisitGeneralInfoDTO>();

            if (visit == null)
            {
                result.Success = false;
                result.DataResult = new VisitGeneralInfoDTO();
                result.ErrorMessage = $"Visit with ID {visitId} not exists";
            }
            else
            {
                var visitDTO = new VisitGeneralInfoDTO();
                visitDTO.VisitGeneralInfo = visit;

                var visitDestinations = await _dbContext.VISIT_DESTINATION_INFO.Where(x => x.VISIT_ID == visitId).ToListAsync();
                visitDTO.VisitDestinationInfo = visitDestinations;

                result.Success = true;
                result.DataResult = visitDTO;
                result.ErrorMessage = "";
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{ErrorMessage}", ex.Message);

            var result = new DataResultModel<VisitGeneralInfoDTO>
            {
                Success = false,
                DataResult = new VisitGeneralInfoDTO(),
                ErrorMessage = "Get visit failed"
            };

            return result;
        }
    }
}
