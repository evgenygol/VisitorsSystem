using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Commands.Visit;
using VisitService.Domain.DTO;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Commands.Visit;

public class UpdateVisitDeleteStatusCommand : IUpdateVisitDeleteStatusCommand
{
    private readonly ApplicationDBContext _dbContext;
    private readonly ILogger<UpdateVisitDeleteStatusCommand> _logger;

    public UpdateVisitDeleteStatusCommand(ApplicationDBContext dbContext, ILogger<UpdateVisitDeleteStatusCommand> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public async Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitDeleteStatusByIdAsync(int visitId)
    {
        try
        {
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
                visit.DELETED = true;
                visit.LAST_CHANGED = DateTime.Now;
                _dbContext.SaveChanges();

                result.Success = true;
                result.DataResult.VisitGeneralInfo = visit;
                result.ErrorMessage = "";
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{UpdateVisitDeleteStatus}", ex.Message);

            var result = new DataResultModel<VisitGeneralInfoDTO>
            {
                Success = false,
                DataResult = new VisitGeneralInfoDTO(),
                ErrorMessage = "Delete visit failed"
            };

            return result;
        }
    }
}
