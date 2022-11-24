using Microsoft.EntityFrameworkCore;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Domain.Destination;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Destination;

internal class GetBuildingsQuery : IGetBuildingsQuery
{
    private readonly ApplicationDBContext _dbContext;
    public GetBuildingsQuery(ApplicationDBContext dbContext) => _dbContext = dbContext;
    public async Task<List<Building>> GetBuildingsAsync() => await _dbContext.BUILDINGS.ToListAsync();
}
