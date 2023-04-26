using VisitService.Application.Model;
using VisitService.Domain.DTO;

namespace VisitService.Application.Repositories.Visits.Commands.Visit;

public interface IUpdateVisitCommand
{
    Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitAsync(VisitGeneralInfoDTO visit);
}
