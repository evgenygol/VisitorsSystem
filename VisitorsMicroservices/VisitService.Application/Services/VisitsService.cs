using VisitService.Application.Model;
using VisitService.Application.Repositories;
using VisitService.Application.Services.Interfaces;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Services;

public class VisitsService : IVisitsService
{
    private readonly IVisitsRepository _visitsRepository;

    public VisitsService(IVisitsRepository visitsRepository)
    {
        _visitsRepository = visitsRepository;
    }

    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsAsync() => await _visitsRepository.GetVisitsAsync();
    public async Task<DataResultModel<VisitGeneralInfoDTO>> GetVisitByIdAsync(int visitId) => await _visitsRepository.GetVisitByIdAsync(visitId);
    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsByInviterIdAsync(int inviterId) => await _visitsRepository.GetVisitsByInviterIdAsync(inviterId);
    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate) => await _visitsRepository.GetVisitsFilterByDatesAsync(startDate, endDate);
    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByTimeTicksAsync(long startDateInTicks, long endDateInTicks)
    {
        DateTime startDate = new DateTime(startDateInTicks);
        DateTime endDate = new DateTime(endDateInTicks);

        return await _visitsRepository.GetVisitsFilterByDatesAsync(startDate, endDate);
    }

    public async Task<DataListResultModel<VisitType>> GetVisitTypesAsync() => await _visitsRepository.GetVisitTypesAsync();
        public async Task<DataListResultModel<Campus>> GetCampusesAsync() => await _visitsRepository.GetCampusesAsync();
    public async Task<DataListResultModel<Building>> GetBuildingsAsync() => await _visitsRepository.GetBuildingsAsync();
    public async Task<DataListResultModel<Floor>> GetFloorsAsync() => await _visitsRepository.GetFloorsAsync();


    public async Task<DataResultModel<VisitGeneralInfoDTO>> DeleteVisitAsync(int visitId) => await _visitsRepository.UpdateVisitDeleteStatusByIdAsync(visitId);


    public async Task<DataResultModel<VisitGeneralInfoDTO>> ProcessAddVisitAsync(VisitGeneralInfoDTO visit) => await _visitsRepository.CreateVisitAsync(visit);
    public async Task<DataResultModel<VisitGeneralInfoDTO>> ProcessUpdateVisitAsync(VisitGeneralInfoDTO visit) => await _visitsRepository.UpdateVisitAsync(visit);

}
