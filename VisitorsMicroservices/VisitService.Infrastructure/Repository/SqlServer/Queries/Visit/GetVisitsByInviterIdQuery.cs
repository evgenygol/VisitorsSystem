using Microsoft.EntityFrameworkCore;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitsByInviterIdQuery: IGetVisitsByInviterIdQuery
{
    private readonly ApplicationDBContext _dbContext;
    public GetVisitsByInviterIdQuery(ApplicationDBContext dbContext) => _dbContext = dbContext;

    public async Task<List<VisitGeneralInfo>> GetVisitsByInviterIdAsync(int inviterId)
    {
        return await _dbContext.VISIT_GENERAL_INFO.Where(x => x.INVITER_ID == inviterId).ToListAsync();
    }
}
