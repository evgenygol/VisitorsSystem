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
    private readonly IGetVisitsFilterByDatesQuery _getVisitsFilterByDatesQuery;

    private readonly IGetVisitTypesQuery _getVisitTypesQuery;
    private readonly IGetVisitPurposesQuery _getVisitPurposesQuery;
    private readonly IGetCampusesQuery _getCampusesQuery;
    private readonly IGetBuildingsQuery _getBuildingsQuery;
    private readonly IGetFloorsQuery _getFloorsQuery;



    public VisitsRepository(IGetVisitsQuery getVisitsQuery, IGetVisitByIdQuery getVisitByIdQuery, 
        IGetVisitsByInviterIdQuery getVisitsByInviterIdQuery, IGetVisitTypesQuery getVisitTypesQuery,
        IGetVisitPurposesQuery getVisitPurposesQuery, IGetCampusesQuery getCampusesQuery,
        IGetBuildingsQuery getBuildingsQuery, IGetFloorsQuery getFloorsQuery,
        IGetVisitsFilterByDatesQuery getVisitsFilterByDatesQuery)
    {
        _getVisitsQuery = getVisitsQuery;
        _getVisitTypesQuery = getVisitTypesQuery;
        _getVisitPurposesQuery = getVisitPurposesQuery;
        _getCampusesQuery = getCampusesQuery;
        _getVisitByIdQuery = getVisitByIdQuery;
        _getVisitsByInviterIdQuery = getVisitsByInviterIdQuery;
        _getBuildingsQuery = getBuildingsQuery;
        _getFloorsQuery = getFloorsQuery;
        _getVisitsFilterByDatesQuery = getVisitsFilterByDatesQuery;
    }

    public Task<DataListResultModel<VisitGeneralInfo>> GetVisitsAsync() => _getVisitsQuery.GetVisitsAsync();
    
    public Task<DataResultModel<VisitGeneralInfo>> GetVisitByIdAsync(int visitId) => _getVisitByIdQuery.GetVisitByIdAsync(visitId);
    
    public Task<DataListResultModel<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId) => _getVisitsByInviterIdQuery.GetVisitsByInviterIdAsync(inviterId);
    
    public Task<DataListResultModel<VisitGeneralInfo>> GetVisitsFilterByDatesAsync(DateTime startDate, DateTime endDate) => _getVisitsFilterByDatesQuery.GetVisitsFilterByDatesAsync(startDate, endDate);


    public Task<DataListResultModel<VisitType>> GetVisitTypesAsync() => _getVisitTypesQuery.GetVisitTypesAsync();

    public Task<DataListResultModel<VisitPurpose>> GetVisitPurposesAsync() => _getVisitPurposesQuery.GetVisitPurposesAsync();

    public Task<DataListResultModel<Campus>> GetCampusesAsync() => _getCampusesQuery.GetCampusesAsync();
    public Task<DataListResultModel<Building>> GetBuildingsAsync() => _getBuildingsQuery.GetBuildingsAsync();

    public Task<DataListResultModel<Floor>> GetFloorsAsync() => _getFloorsQuery.GetFloorsAsync();

}
