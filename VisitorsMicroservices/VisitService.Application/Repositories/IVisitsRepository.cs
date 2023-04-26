using VisitService.Application.Model;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Repositories;

public interface IVisitsRepository
{
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync();
    Task<DataResultModel<VisitGeneralInfoDTO>> GetVisitByIdAsync(int visitId);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate);

    Task<DataListResultModel<VisitType>> GetVisitTypesAsync();
    Task<DataListResultModel<Campus>> GetCampusesAsync();
    Task<DataListResultModel<Building>> GetBuildingsAsync();
    Task<DataListResultModel<Floor>> GetFloorsAsync();

    Task<DataResultModel<VisitGeneralInfo>> UpdateVisitDeleteStatusByIdAsync(int visitId);

    Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitAsync(VisitGeneralInfoDTO visit);

}
