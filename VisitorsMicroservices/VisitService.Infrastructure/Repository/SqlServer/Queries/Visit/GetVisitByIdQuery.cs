using Microsoft.EntityFrameworkCore;
using VisitService.Application.Repositories.Visits.Queries.Visit;
using VisitService.Domain.Visit;
using VisitService.Infrastructure.Persistence;

namespace VisitService.Infrastructure.Repository.SqlServer.Queries.Visit;

public class GetVisitByIdQuery : IGetVisitByIdQuery
{
    private readonly ApplicationDBContext _dbContext;
    public GetVisitByIdQuery(ApplicationDBContext dbContext) => _dbContext = dbContext;

	public async Task<VisitGeneralInfo> GetVisitByIdAsync(int visitId)
	{
        return await _dbContext.VISIT_GENERAL_INFO.Where(x => x.ID == visitId).FirstOrDefaultAsync();
    }
}
