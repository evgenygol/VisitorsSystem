using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Commands.Visit;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.DTO;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Repositories;

public class VisitsRepository : IVisitsRepository
{
    private readonly IGetVisitsQuery _getVisitsQuery;
    private readonly IGetVisitByIdQuery _getVisitByIdQuery;
    private readonly IGetVisitsByInviterIdQuery _getVisitsByInviterIdQuery;
    private readonly IGetVisitsFilterByDatesQuery _getVisitsFilterByDatesQuery;

    private readonly IGetVisitTypesQuery _getVisitTypesQuery;
    private readonly IGetCampusesQuery _getCampusesQuery;
    private readonly IGetBuildingsQuery _getBuildingsQuery;
    private readonly IGetFloorsQuery _getFloorsQuery;

    private readonly IUpdateVisitDeleteStatusCommand _updateVisitDeleteStatusCommand;

    private readonly ICreateVisitCommand _createVisitCommand;
    private readonly IUpdateVisitCommand _updateVisitCommand;


    public VisitsRepository(IGetVisitsQuery getVisitsQuery, IGetVisitByIdQuery getVisitByIdQuery, 
        IGetVisitsByInviterIdQuery getVisitsByInviterIdQuery, IGetVisitTypesQuery getVisitTypesQuery,
        IGetCampusesQuery getCampusesQuery,IGetBuildingsQuery getBuildingsQuery,
        IGetFloorsQuery getFloorsQuery, IGetVisitsFilterByDatesQuery getVisitsFilterByDatesQuery,
        IUpdateVisitDeleteStatusCommand updateVisitDeleteStatusCommand, ICreateVisitCommand createVisitCommand,
        IUpdateVisitCommand updateVisitCommand
        )
    {
        _getVisitsQuery = getVisitsQuery;
        _getVisitTypesQuery = getVisitTypesQuery;
        _getCampusesQuery = getCampusesQuery;
        _getVisitByIdQuery = getVisitByIdQuery;
        _getVisitsByInviterIdQuery = getVisitsByInviterIdQuery;
        _getBuildingsQuery = getBuildingsQuery;
        _getFloorsQuery = getFloorsQuery;
        _getVisitsFilterByDatesQuery = getVisitsFilterByDatesQuery;
        _updateVisitDeleteStatusCommand = updateVisitDeleteStatusCommand;
        _createVisitCommand = createVisitCommand;
        _updateVisitCommand = updateVisitCommand;
    }

    public Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsAsync() => _getVisitsQuery.GetVisitsAsync();
    
    public Task<DataResultModel<VisitGeneralInfoDTO>> GetVisitByIdAsync(int visitId) => _getVisitByIdQuery.GetVisitByIdAsync(visitId);
    
    public Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsByInviterIdAsync(int inviterId) => _getVisitsByInviterIdQuery.GetVisitsByInviterIdAsync(inviterId);
    
    public Task<DataListResultModel<VisitGeneralInfoDTO>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate) => _getVisitsFilterByDatesQuery.GetVisitsFilterByDatesAsync(startDate, endDate);


    public Task<DataListResultModel<VisitType>> GetVisitTypesAsync() => _getVisitTypesQuery.GetVisitTypesAsync();

    public Task<DataListResultModel<Campus>> GetCampusesAsync() => _getCampusesQuery.GetCampusesAsync();
    public Task<DataListResultModel<Building>> GetBuildingsAsync() => _getBuildingsQuery.GetBuildingsAsync();

    public Task<DataListResultModel<Floor>> GetFloorsAsync() => _getFloorsQuery.GetFloorsAsync();

    public Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitDeleteStatusByIdAsync(int visitId) => _updateVisitDeleteStatusCommand.UpdateVisitDeleteStatusByIdAsync(visitId);

    public Task<DataResultModel<VisitGeneralInfoDTO>> CreateVisitAsync(VisitGeneralInfoDTO visit) => _createVisitCommand.CreateVisitAsync(visit);
    public Task<DataResultModel<VisitGeneralInfoDTO>> UpdateVisitAsync(VisitGeneralInfoDTO visit) => _updateVisitCommand.UpdateVisitAsync(visit);
}
