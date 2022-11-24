using Microsoft.EntityFrameworkCore;
using VisitService.Application.Common.Interfaces;
using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

namespace VisitService.Infrastructure.Persistence;

public class ApplicationDBContext : DbContext, IApplicationDBContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
             : base(options)
    {
    }
    public DbSet<VisitGeneralInfo> VISIT_GENERAL_INFO { get; set; }
    public DbSet<VisitType> VISIT_TYPES { get; set; }
    public DbSet<VisitPurpose> VISIT_PURPOSES { get; set; }
    public DbSet<Campus> CAMPUSES { get; set; }
    public DbSet<Building> BUILDINGS { get; set; }
    public DbSet<Floor> FLOORS { get; set; }
}
