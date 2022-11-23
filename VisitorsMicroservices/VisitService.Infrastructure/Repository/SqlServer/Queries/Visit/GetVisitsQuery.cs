using Microsoft.EntityFrameworkCore;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitsQuery : IGetVisitsQuery
{
    private readonly ApplicationDBContext _dbContext;
    public GetVisitsQuery(ApplicationDBContext dbContext) => _dbContext = dbContext;
    public async Task<List<VisitGeneralInfo>> GetVisitsAsync() => await _dbContext.VISIT_GENERAL_INFO.ToListAsync();
}
