using VisitService.Application.Model;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Repositories;

public interface IVisitsRepository
{
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsAsync();
    Task<DataResultModel<VisitGeneralInfoDTO>> GetVisitByIdAsync(int visitId);
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsByInviterIdAsync(int inviterId);
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate);

    Task<DataListResultModel<VisitType>> GetVisitTypesAsync();
    Task<DataListResultModel<Campus>> GetCampusesAsync();
    Task<DataListResultModel<Building>> GetBuildingsAsync();
    Task<DataListResultModel<Floor>> GetFloorsAsync();

    Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitDeleteStatusByIdAsync(int visitId);
    Task<DataResultModel<VisitGeneralInfoDTO>> CreateVisitAsync(VisitGeneralInfoDTO visit);
    Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitAsync(VisitGeneralInfoDTO visit);

}
