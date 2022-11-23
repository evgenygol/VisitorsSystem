using Microsoft.EntityFrameworkCore;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Domain.Destination;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Destination;

internal class GetCampusesQuery : IGetCampusesQuery
{
    private readonly ApplicationDBContext _dbContext;
    public GetCampusesQuery(ApplicationDBContext dbContext) => _dbContext = dbContext;
    public async Task<List<Campus>> GetCampusesAsync() => await _dbContext.CAMPUSES.ToListAsync();
}
