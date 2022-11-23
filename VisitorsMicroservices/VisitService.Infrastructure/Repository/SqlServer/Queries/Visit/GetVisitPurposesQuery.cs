using Microsoft.EntityFrameworkCore;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitPurposesQuery : IGetVisitPurposesQuery
{
    private readonly ApplicationDBContext _dbContext;
    public GetVisitPurposesQuery(ApplicationDBContext dbContext) => _dbContext = dbContext;
    public async Task<List<VisitPurpose>> GetVisitPurposesAsync() => await _dbContext.VISIT_PURPOSES.ToListAsync();
}
