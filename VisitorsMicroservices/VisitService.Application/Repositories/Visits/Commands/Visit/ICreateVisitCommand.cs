using VisitService.Application.Model;
using VisitService.Domain.DTO;

namespace VisitService.Application.Repositories.Visits.Commands.Visit
{
    public interface ICreateVisitCommand
    {
        Task<DataResultModel<VisitGeneralInfoDTO>> CreateVisitAsync(VisitGeneralInfoDTO visit);
    }
}
