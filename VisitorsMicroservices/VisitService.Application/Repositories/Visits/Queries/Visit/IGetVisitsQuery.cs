using VisitService.Application.Model;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitsQuery
{
    Task<VisitsResultModel> GetVisitsAsync();
}
