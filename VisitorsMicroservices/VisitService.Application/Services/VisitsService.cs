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
    public async Task<List<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId) => await _visitsRepository.GetVisitsByInviterIdAsync(inviterId);


    public async Task<List<VisitType>> GetVisitTypesAsync() => await _visitsRepository.GetVisitTypesAsync();

    public async Task<List<VisitPurpose>> GetVisitPurposesAsync() => await _visitsRepository.GetVisitPurposesAsync();

    public async Task<List<Campus>> GetCampusesAsync() => await _visitsRepository.GetCampusesAsync();
    public async Task<List<Building>> GetBuildingsAsync() => await _visitsRepository.GetBuildingsAsync();
    public async Task<List<Floor>> GetFloorsAsync() => await _visitsRepository.GetFloorsAsync();

}
