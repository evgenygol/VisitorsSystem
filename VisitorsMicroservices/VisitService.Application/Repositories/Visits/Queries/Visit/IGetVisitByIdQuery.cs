using VisitService.Application.Model;
using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitByIdQuery
{
    Task<DataResultModel<VisitGeneralInfo>> GetVisitByIdAsync(int visitId);
}
