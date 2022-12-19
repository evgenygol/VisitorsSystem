using VisitService.Application.Model;
using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories.Visits.Commands.Visit;

public interface IUpdateVisitDeleteStatusCommand
{
    Task<DataResultModel<VisitGeneralInfo>> UpdateVisitDeleteStatusByIdAsync(int visitId);

}
