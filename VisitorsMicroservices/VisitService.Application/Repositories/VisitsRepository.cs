using VisitService.Application.Model;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

namespace VisitService.Application.Repositories;

public class VisitsRepository : IVisitsRepository
{
    private readonly IGetVisitsQuery _getVisitsQuery;
    private readonly IGetVisitByIdQuery _getVisitByIdQuery;
    private readonly IGetVisitsByInviterIdQuery _getVisitsByInviterIdQuery;
    private readonly IGetVisitTypesQuery _getVisitTypesQuery;
    private readonly IGetVisitPurposesQuery _getVisitPurposesQuery;
    private readonly IGetCampusesQuery _getCampusesQuery;
    private readonly IGetBuildingsQuery _getBuildingsQuery;
    private readonly IGetFloorsQuery _getFloorsQuery;



    public VisitsRepository(IGetVisitsQuery getVisitsQuery, IGetVisitByIdQuery getVisitByIdQuery, 
        IGetVisitsByInviterIdQuery getVisitsByInviterIdQuery, IGetVisitTypesQuery getVisitTypesQuery, 
        IGetVisitPurposesQuery getVisitPurposesQuery, IGetCampusesQuery getCampusesQuery,
        IGetBuildingsQuery getBuildingsQuery, IGetFloorsQuery getFloorsQuery
        )
    {
        _getVisitsQuery = getVisitsQuery;
        _getVisitTypesQuery = getVisitTypesQuery;
        _getVisitPurposesQuery = getVisitPurposesQuery;
        _getCampusesQuery = getCampusesQuery;
        _getVisitByIdQuery = getVisitByIdQuery;
        _getVisitsByInviterIdQuery = getVisitsByInviterIdQuery;
        _getBuildingsQuery = getBuildingsQuery;
        _getFloorsQuery = getFloorsQuery;
    }

    public Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync() => _getVisitsQuery.GetVisitsAsync();
    public Task<DataResultModel<VisitGeneralInfo>> GetVisitByIdAsync(int visitId) => _getVisitByIdQuery.GetVisitByIdAsync(visitId);
    public Task<List<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId) => _getVisitsByInviterIdQuery.GetVisitsByInviterIdAsync(inviterId);

    public Task<List<VisitType>> GetVisitTypesAsync() => _getVisitTypesQuery.GetVisitTypesAsync();

    public Task<List<VisitPurpose>> GetVisitPurposesAsync() => _getVisitPurposesQuery.GetVisitPurposesAsync();

    public Task<List<Campus>> GetCampusesAsync() => _getCampusesQuery.GetCampusesAsync();
    public Task<List<Building>> GetBuildingsAsync() => _getBuildingsQuery.GetBuildingsAsync();

    public Task<List<Floor>> GetFloorsAsync() => _getFloorsQuery.GetFloorsAsync();

}
