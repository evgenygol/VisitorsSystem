using VisitService.Application.Model;
using VisitService.Domain.DTO;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitsFilterByDatesQuery
{
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate);
}
