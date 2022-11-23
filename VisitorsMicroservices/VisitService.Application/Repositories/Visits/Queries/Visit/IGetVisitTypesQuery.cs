using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitTypesQuery
{
    Task<List<VisitType>> GetVisitTypesAsync();

}
