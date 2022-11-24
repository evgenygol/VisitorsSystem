using VisitService.Domain.Destination;

namespace VisitService.Application.Repositories.Visits.Queries.Destination;

public interface IGetBuildingsQuery
{
    Task<List<Building>> GetBuildingsAsync();
}
