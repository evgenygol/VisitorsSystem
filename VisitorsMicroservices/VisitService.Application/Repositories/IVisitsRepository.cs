using VisitService.Application.Model;
using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories;

public interface IVisitsRepository
{
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync();
    Task<DataResultModel<VisitGeneralInfo>> GetVisitByIdAsync(int visitId);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId);
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate);

    Task<DataListResultModel<VisitType>> GetVisitTypesAsync();
    Task<DataListResultModel<VisitPurpose>> GetVisitPurposesAsync();
    Task<DataListResultModel<Campus>> GetCampusesAsync();
    Task<DataListResultModel<Building>> GetBuildingsAsync();
    Task<DataListResultModel<Floor>> GetFloorsAsync();
}
