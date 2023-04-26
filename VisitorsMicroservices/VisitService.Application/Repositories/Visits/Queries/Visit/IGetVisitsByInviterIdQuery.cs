using VisitService.Application.Model;
using VisitService.Domain.DTO;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitsByInviterIdQuery
{
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsByInviterIdAsync(int inviterId);
}
