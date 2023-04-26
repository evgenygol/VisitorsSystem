using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Commands.Visit;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Commands.Visit;

public class UpdateVisitCommand : IUpdateVisitCommand
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<UpdateVisitCommand> _logger;

    public UpdateVisitCommand(ApplicationDBContext dbContext, ILogger<UpdateVisitCommand> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitAsync(VisitGeneralInfoDTO visitDTO)
    {
        try
        {
            var visit = await _dbContext.VISIT_GENERAL_INFO.Where(x => x.ID == visitDTO.VisitGeneralInfo.ID).FirstOrDefaultAsync();

            var result = new DataResultModel<VisitGeneralInfoDTO>();

            if (visit == null)
            {
                result.Success = false;
                result.DataResult = new VisitGeneralInfoDTO();
                result.ErrorMessage = $"Visit with ID {visitDTO.VisitGeneralInfo.ID} not exists";
            }
            else
            {
                //update visit general info
                visit.VISIT_NAME = visitDTO.VisitGeneralInfo.VISIT_NAME;
                visit.VISIT_TYPE_ID = visitDTO.VisitGeneralInfo.VISIT_TYPE_ID;
                visit.VISIT_REMARKS = visitDTO.VisitGeneralInfo.VISIT_REMARKS;
                visit.VISIT_START_DATE = visitDTO.VisitGeneralInfo.VISIT_START_DATE;
                visit.VISIT_END_DATE = visitDTO.VisitGeneralInfo.VISIT_END_DATE;
                visit.INVITER_ID = visitDTO.VisitGeneralInfo.INVITER_ID;
                visit.ESCORT_ID = visitDTO.VisitGeneralInfo.ESCORT_ID;
                visit.HOST_ID = visitDTO.VisitGeneralInfo.HOST_ID;
                visit.LAST_CHANGED_BY_EMPID = visitDTO.VisitGeneralInfo.LAST_CHANGED_BY_EMPID;
                visit.LAST_CHANGED = DateTime.Now;

                //update visit destination info
                var visitDestinations = await _dbContext.VISIT_DESTINATION_INFO.Where(x => x.VISIT_ID == visit.ID).ToListAsync();
                _dbContext.VISIT_DESTINATION_INFO.RemoveRange(visitDestinations);
                await _dbContext.VISIT_DESTINATION_INFO.AddRangeAsync(visitDTO.VisitDestinationInfo);
                _dbContext.SaveChanges();

                result.Success = true;
                result.DataResult = visitDTO;
                result.ErrorMessage = "";
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{UpdateVisit}", ex.Message);

            var result = new DataResultModel<VisitGeneralInfoDTO>
            {
                Success = false,
                DataResult = new VisitGeneralInfoDTO(),
                ErrorMessage = "Update visit failed"
            };

            return result;
        }
    }
}
