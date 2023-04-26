using VisitService.Application.Model;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitsFilterByDatesQuery
{
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate);
}
