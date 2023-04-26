using VisitService.Application.Model;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitsByInviterIdQuery
{
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId);
}
