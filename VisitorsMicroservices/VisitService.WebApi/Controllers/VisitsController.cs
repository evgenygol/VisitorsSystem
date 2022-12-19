using Microsoft.AspNetCore.Mvc;
using VisitService.Application.Model;
using VisitService.Application.Services.Interfaces;
using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

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
    public async Task<DataListResultModel<VisitGeneralInfo>> Get() => await _visitsService.GetVisitsAsync();

    [HttpGet("{visitId}")]
    public async Task<DataResultModel<VisitGeneralInfo>> Get([FromRoute] int visitId) => await _visitsService.GetVisitByIdAsync(visitId);

    [HttpGet("VisitsByInviterId/{inviterId}")]
    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterId([FromRoute] int inviterId) => await _visitsService.GetVisitsByInviterIdAsync(inviterId);

    [Route(@"GetVisitsFilterByDates/{startDate:DateTime}/{endDate:DateTime}")]
    [HttpGet]
    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByDates([FromRoute] DateTime startDate, [FromRoute] DateTime endDate) => await _visitsService.GetVisitsFilterByDatesAsync(startDate, endDate);

    [Route(@"GetVisitsFilterByTimeTicks/{startDateInTicks:long}/{endDateInTicks:long}")]
    [HttpGet]
    public async Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByTimeTicks([FromRoute] long startDateInTicks, [FromRoute] long endDateInTicks) => await _visitsService.GetVisitsFilterByTimeTicksAsync(startDateInTicks, endDateInTicks);

    [HttpGet("GetVisitTypes")]
    public async Task<DataListResultModel<VisitType>> GetVisitTypes() => await _visitsService.GetVisitTypesAsync();

    [HttpGet("GetVisitPurposes")]
    public async Task<DataListResultModel<VisitPurpose>> GetVisitPurposes() => await _visitsService.GetVisitPurposesAsync();

    [HttpGet("GetCampuses")]
    public async Task<DataListResultModel<Campus>> GetCampuses() => await _visitsService.GetCampusesAsync();

    [HttpGet("GetBuildings")]
    public async Task<DataListResultModel<Building>> GetBuildings() => await _visitsService.GetBuildingsAsync();

    [HttpGet("GetFloors")]
    public async Task<DataListResultModel<Floor>> GetFloors() => await _visitsService.GetFloorsAsync();




    [HttpDelete("{visitId}")]
    public async Task<DataResultModel<VisitGeneralInfo>> Delete([FromQuery] int visitId) => await _visitsService.DeleteVisitAsync(visitId);
}
