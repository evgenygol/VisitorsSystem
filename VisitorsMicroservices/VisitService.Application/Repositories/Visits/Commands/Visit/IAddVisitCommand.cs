using VisitService.Application.Model;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Repositories.Visits.Commands.Visit
{
    public interface IAddVisitCommand
    {
        Task<DataResultModel<VisitGeneralInfoDTO>> AddVisitAsync(VisitGeneralInfoDTO visit);
    }
}
