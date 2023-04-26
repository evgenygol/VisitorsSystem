using Microsoft.AspNetCore.Mvc;
using VisitService.Application.Model;
using VisitService.Application.Services.Interfaces;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    private readonly IVisitsService _visitsService;

	public VisitsController(IVisitsService visitsService)
	{
        _visitsService = visitsService;
    }

    [HttpGet]
    public async Task<DataListResultModel<VisitGeneralInfoDTO>> Get() => await _visitsService.GetVisitsAsync();

    [HttpGet("{visitId}")]
    public async Task<DataResultModel<VisitGeneralInfoDTO>> Get([FromRoute] int visitId) => await _visitsService.GetVisitByIdAsync(visitId);

    [HttpGet("VisitsByInviterId/{inviterId}")]
    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsByInviterId([FromRoute] int inviterId) => await _visitsService.GetVisitsByInviterIdAsync(inviterId);

    [Route(@"GetVisitsFilterByDates/{startDate:DateTime}/{endDate:DateTime}")]
    [HttpGet]
    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByDates([FromRoute] DateTime startDate, [FromRoute] DateTime endDate) => await _visitsService.GetVisitsFilterByDatesAsync(startDate, endDate);

    [Route(@"GetVisitsFilterByTimeTicks/{startDateInTicks:long}/{endDateInTicks:long}")]
    [HttpGet]
    public async Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByTimeTicks([FromRoute] long startDateInTicks, [FromRoute] long endDateInTicks) => await _visitsService.GetVisitsFilterByTimeTicksAsync(startDateInTicks, endDateInTicks);

    [HttpGet("GetVisitTypes")]
    public async Task<DataListResultModel<VisitType>> GetVisitTypes() => await _visitsService.GetVisitTypesAsync();

    [HttpGet("GetCampuses")]
    public async Task<DataListResultModel<Campus>> GetCampuses() => await _visitsService.GetCampusesAsync();

    [HttpGet("GetBuildings")]
    public async Task<DataListResultModel<Building>> GetBuildings() => await _visitsService.GetBuildingsAsync();

    [HttpGet("GetFloors")]
    public async Task<DataListResultModel<Floor>> GetFloors() => await _visitsService.GetFloorsAsync();




    [HttpDelete("{visitId}")]
    public async Task<DataResultModel<VisitGeneralInfoDTO>> Delete(int visitId) => await _visitsService.DeleteVisitAsync(visitId);


    [Route(@"AddVisit")]
    [HttpPost]
    public async Task<DataResultModel<VisitGeneralInfoDTO>> AddVisit([FromBody] VisitGeneralInfoDTO visit) => await _visitsService.ProcessAddVisitAsync(visit);
    [Route(@"UpdateVisit")]
    [HttpPost]
    public async Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisit([FromBody] VisitGeneralInfoDTO visit) => await _visitsService.ProcessUpdateVisitAsync(visit);
}
