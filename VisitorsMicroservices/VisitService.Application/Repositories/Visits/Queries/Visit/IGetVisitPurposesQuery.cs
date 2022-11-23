using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitPurposesQuery
{
    Task<List<VisitPurpose>> GetVisitPurposesAsync();
}
