using VisitService.Domain.Destination;

namespace VisitService.Application.Repositories.Visits.Queries.Destination;

public interface IGetFloorsQuery
{
    Task<List<Floor>> GetFloorsAsync();
}
