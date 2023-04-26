using VisitService.Application.Model;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Services.Interfaces;

public interface IVisitsService
{
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync();
    Task<DataResultModel<VisitGeneralInfoDTO>> GetVisitByIdAsync(int visitId);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByTimeTicksAsync(long startDateInTicks, long endDateInTicks);


    Task<DataListResultModel<VisitType>> GetVisitTypesAsync();
    Task<DataListResultModel<Campus>> GetCampusesAsync();
    Task<DataListResultModel<Building>> GetBuildingsAsync();
    Task<DataListResultModel<Floor>> GetFloorsAsync();


    Task<DataResultModel<VisitGeneralInfo>> DeleteVisitAsync(int visitId);


    Task<DataResultModel<VisitGeneralInfoDTO>> ProcessVisitAsync(VisitGeneralInfoDTO visit);

}
