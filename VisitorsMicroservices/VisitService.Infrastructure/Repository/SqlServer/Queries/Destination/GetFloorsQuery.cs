using Microsoft.EntityFrameworkCore;
using VisitService.Application.Repositories.Visits.Queries.Destination;
using VisitService.Domain.Destination;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Destination;

internal class GetFloorsQuery : IGetFloorsQuery
{
    private readonly ApplicationDBContext _dbContext;
    public GetFloorsQuery(ApplicationDBContext dbContext) => _dbContext = dbContext;
    public async Task<List<Floor>> GetFloorsAsync() => await _dbContext.FLOORS.ToListAsync();
}

