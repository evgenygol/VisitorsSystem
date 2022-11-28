using Microsoft.AspNetCore.Mvc;
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
    public async Task<List<VisitGeneralInfo>> Get() => await _visitsService.GetVisitsAsync();

    [HttpGet("{visitId}")]
    public async Task<VisitGeneralInfo> Get([FromRoute] int visitId) => await _visitsService.GetVisitByIdAsync(visitId);

    [HttpGet("VisitsByInviterId/{inviterId}")]
    public async Task<List<VisitGeneralInfo>> GetVisitsByInviterId([FromRoute] int inviterId) => await _visitsService.GetVisitsByInviterIdAsync(inviterId);

    [Route(@"VisitsByDates/{startDate:DateTime}/{endDate:DateTime}")]
    [HttpGet]
    public async Task<List<VisitGeneralInfo>> GetVisitsByDates([FromRoute] DateTime startDate, [FromRoute] DateTime endDate) => await _visitsService.GetVisitsAsync();

    [Route(@"VisitsByDates/{startDateInMls:long}/{endDateInMls:long}")]
    [HttpGet]
    public async Task<List<VisitGeneralInfo>> GetVisitsByDates([FromRoute] long startDateInMls, [FromRoute] long endDateInMls) => await _visitsService.GetVisitsAsync();

    [HttpGet("GetVisitTypes")]
    public async Task<List<VisitType>> GetVisitTypes() => await _visitsService.GetVisitTypesAsync();

    [HttpGet("GetVisitPurposes")]
    public async Task<List<VisitPurpose>> GetVisitPurposes() => await _visitsService.GetVisitPurposesAsync();

    [HttpGet("GetCampuses")]
    public async Task<List<Campus>> GetCampuses() => await _visitsService.GetCampusesAsync();

    [HttpGet("GetBuildings")]
    public async Task<List<Building>> GetBuildings() => await _visitsService.GetBuildingsAsync();

    [HttpGet("GetFloors")]
    public async Task<List<Floor>> GetFloors() => await _visitsService.GetFloorsAsync();
}
