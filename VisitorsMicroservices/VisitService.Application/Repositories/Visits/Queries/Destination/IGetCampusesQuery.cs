using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Destination;

public interface IGetCampusesQuery
{
    Task<List<Campus>> GetCampusesAsync();

}
