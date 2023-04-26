using VisitService.Application.Model;
using VisitService.Domain.DTO;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitsQuery
{
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsAsync();
}
