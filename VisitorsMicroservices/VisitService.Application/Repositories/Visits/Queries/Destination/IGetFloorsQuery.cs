using VisitService.Application.Model;
using VisitService.Domain.Destination;

namespace VisitService.Application.Repositories.Visits.Queries.Destination;

public interface IGetFloorsQuery
{
    Task<DataListResultModel<Floor>> GetFloorsAsync();
}
