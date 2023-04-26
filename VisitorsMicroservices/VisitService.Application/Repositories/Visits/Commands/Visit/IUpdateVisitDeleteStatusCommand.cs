using VisitService.Application.Model;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Repositories.Visits.Commands.Visit;

public interface IUpdateVisitDeleteStatusCommand
{
    Task<DataResultModel<VisitGeneralInfo>> UpdateVisitDeleteStatusByIdAsync(int visitId);

}
