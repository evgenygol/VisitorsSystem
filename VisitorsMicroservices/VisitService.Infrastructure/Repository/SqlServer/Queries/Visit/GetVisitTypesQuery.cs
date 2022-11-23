using Microsoft.EntityFrameworkCore;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

internal class GetVisitTypesQuery : IGetVisitTypesQuery
{
    private readonly ApplicationDBContext _dbContext;
    public GetVisitTypesQuery(ApplicationDBContext dbContext) => _dbContext = dbContext;
    public async Task<List<VisitType>> GetVisitTypesAsync() => await _dbContext.VISIT_TYPES.ToListAsync();
}
