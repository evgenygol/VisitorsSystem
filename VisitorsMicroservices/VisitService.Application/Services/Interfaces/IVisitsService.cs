using VisitService.Application.Model;
using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

namespace VisitService.Application.Services.Interfaces;

public interface IVisitsService
{
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync();
    Task<DataResultModel<VisitGeneralInfo>> GetVisitByIdAsync(int visitId);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByTimeTicksAsync(long startDateInTicks, long endDateInTicks);


    Task<DataListResultModel<VisitType>> GetVisitTypesAsync();
    Task<DataListResultModel<VisitPurpose>> GetVisitPurposesAsync();
    Task<DataListResultModel<Campus>> GetCampusesAsync();
    Task<DataListResultModel<Building>> GetBuildingsAsync();
    Task<DataListResultModel<Floor>> GetFloorsAsync();
    Task<DataResultModel<VisitGeneralInfo>> DeleteVisitAsync(int visitId);
}
