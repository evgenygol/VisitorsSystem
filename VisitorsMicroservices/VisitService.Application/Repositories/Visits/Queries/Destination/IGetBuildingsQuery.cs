using VisitService.Application.Model;
using VisitService.Domain.Entity.Destination;

namespace VisitService.Application.Repositories.Visits.Queries.Destination;

public interface IGetBuildingsQuery
{
    Task<DataListResultModel<Building>> GetBuildingsAsync();
}
