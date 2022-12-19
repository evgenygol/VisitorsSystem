using VisitService.Application.Model;
using VisitService.Application.Repositories;
using VisitService.Application.Services.Interfaces;
using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

namespace VisitService.Application.Services;

public class VisitsService : IVisitsService
{
    private readonly IVisitsRepository _visitsRepository;

    public VisitsService(IVisitsRepository visitsRepository)
    {
        _visitsRepository = visitsRepository;
    }

    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync() => await _visitsRepository.GetVisitsAsync();
    public async Task<DataResultModel<VisitGeneralInfo>> GetVisitByIdAsync(int visitId) => await _visitsRepository.GetVisitByIdAsync(visitId);
    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId) => await _visitsRepository.GetVisitsByInviterIdAsync(inviterId);
    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate) => await _visitsRepository.GetVisitsFilterByDatesAsync(startDate, endDate);
    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByTimeTicksAsync(long startDateInTicks, long endDateInTicks)
    {
        DateTime startDate = new DateTime(startDateInTicks);
        DateTime endDate = new DateTime(endDateInTicks);

        return await _visitsRepository.GetVisitsFilterByDatesAsync(startDate, endDate);
    }

    public async Task<DataListResultModel<VisitType>> GetVisitTypesAsync() => await _visitsRepository.GetVisitTypesAsync();

    public async Task<DataListResultModel<VisitPurpose>> GetVisitPurposesAsync() => await _visitsRepository.GetVisitPurposesAsync();

    public async Task<DataListResultModel<Campus>> GetCampusesAsync() => await _visitsRepository.GetCampusesAsync();
    public async Task<DataListResultModel<Building>> GetBuildingsAsync() => await _visitsRepository.GetBuildingsAsync();
    public async Task<DataListResultModel<Floor>> GetFloorsAsync() => await _visitsRepository.GetFloorsAsync();

    public async Task<DataResultModel<VisitGeneralInfo>> DeleteVisitAsync(int visitId) => await _visitsRepository.UpdateVisitDeleteStatusByIdAsync(visitId);

}
