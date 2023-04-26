using VisitService.Application.Model;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Services.Interfaces;

public interface IVisitsService
{
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsAsync();
    Task<DataResultModel<VisitGeneralInfoDTO>> GetVisitByIdAsync(int visitId);
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsByInviterIdAsync(int inviterId);
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate);
    Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByTimeTicksAsync(long startDateInTicks, long endDateInTicks);


    Task<DataListResultModel<VisitType>> GetVisitTypesAsync();
    Task<DataListResultModel<Campus>> GetCampusesAsync();
    Task<DataListResultModel<Building>> GetBuildingsAsync();
    Task<DataListResultModel<Floor>> GetFloorsAsync();


    Task<DataResultModel<VisitGeneralInfoDTO>> DeleteVisitAsync(int visitId);


    Task<DataResultModel<VisitGeneralInfoDTO>> ProcessAddVisitAsync(VisitGeneralInfoDTO visit);
    Task<DataResultModel<VisitGeneralInfoDTO>> ProcessUpdateVisitAsync(VisitGeneralInfoDTO visit);

}
