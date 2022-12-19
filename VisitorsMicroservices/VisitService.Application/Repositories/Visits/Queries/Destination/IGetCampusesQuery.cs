using VisitService.Application.Model;
using VisitService.Domain.Destination;

namespace VisitService.Application.Repositories.Visits.Queries.Destination;

public interface IGetCampusesQuery
{
    Task<DataListResultModel<Campus>> GetCampusesAsync();

}
