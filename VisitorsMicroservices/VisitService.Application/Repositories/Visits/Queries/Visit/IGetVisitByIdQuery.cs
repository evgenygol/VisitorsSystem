using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitByIdQuery
{
    Task<VisitGeneralInfo> GetVisitByIdAsync(int visitId);
}
