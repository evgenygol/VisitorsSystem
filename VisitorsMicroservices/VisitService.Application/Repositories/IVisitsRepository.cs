using VisitService.Application.Model;
using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories;

public interface IVisitsRepository
{
    Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync();
    Task<DataResultModel<VisitGeneralInfo>> GetVisitByIdAsync(int visitId);
    Task<List<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId);

    Task<List<VisitType>> GetVisitTypesAsync();
    Task<List<VisitPurpose>> GetVisitPurposesAsync();
    Task<List<Campus>> GetCampusesAsync();
    Task<List<Building>> GetBuildingsAsync();
    Task<List<Floor>> GetFloorsAsync();
}
