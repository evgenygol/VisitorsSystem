using VisitService.Application.Model;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Repositories.Visits.Queries.Visit;

public interface IGetVisitByIdQuery
{
    Task<DataResultModel<VisitGeneralInfoDTO>> GetVisitByIdAsync(int visitId);
}
