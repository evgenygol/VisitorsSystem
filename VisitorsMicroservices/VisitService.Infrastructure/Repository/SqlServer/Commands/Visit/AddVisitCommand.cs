using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Commands.Visit;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Commands.Visit
{
    public class AddVisitCommand : IAddVisitCommand
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ILogger<AddVisitCommand> _logger;

        public AddVisitCommand(ApplicationDBContext dbContext, ILogger<AddVisitCommand> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<DataResultModel<VisitGeneralInfoDTO>> AddVisitAsync(VisitGeneralInfoDTO visit)
        {
            try
            {
                VisitGeneralInfo visitGeneralInfo = new VisitGeneralInfo();
                visitGeneralInfo = visit.VisitGeneralInfo;

                visitGeneralInfo.CREATED = DateTime.Now;
                visitGeneralInfo.LAST_CHANGED = DateTime.Now;

                await _dbContext.VISIT_GENERAL_INFO.AddAsync(visitGeneralInfo);
                _dbContext.SaveChanges();

                if (visit.VisitDestinationInfo is not null && visit.VisitDestinationInfo.Count > 0)
                {
                    foreach (var visitDestinationInfo in visit.VisitDestinationInfo)
                    {
                        visitDestinationInfo.VISIT_ID = visitGeneralInfo.ID;
                    }
                    await _dbContext.VISIT_DESTINATION_INFO.AddRangeAsync(visit.VisitDestinationInfo);
                    _dbContext.SaveChanges();

                }

                var result = new DataResultModel<VisitGeneralInfoDTO>();
                result.Success = true;
                result.DataResult = visit;
                result.ErrorMessage = "";

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{ErrorMessage}", ex.Message);

                var result = new DataResultModel<VisitGeneralInfoDTO>
                {
                    Success = false,
                    DataResult = new VisitGeneralInfoDTO(),
                    ErrorMessage = "Add visit failed"
                };

                return result;
            }

        }
    }
}
