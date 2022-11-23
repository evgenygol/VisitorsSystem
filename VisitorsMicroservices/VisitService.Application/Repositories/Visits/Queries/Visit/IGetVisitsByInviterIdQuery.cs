using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitsByInviterIdQuery
{
    Task<List<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId);
}
