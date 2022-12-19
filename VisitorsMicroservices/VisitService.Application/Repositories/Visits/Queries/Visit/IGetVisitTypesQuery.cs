using VisitService.Application.Model;
using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitTypesQuery
{
    Task<DataListResultModel<VisitType>> GetVisitTypesAsync();

}
