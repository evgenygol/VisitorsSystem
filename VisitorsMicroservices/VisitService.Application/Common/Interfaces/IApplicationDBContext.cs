using Microsoft.EntityFrameworkCore;
using VisitService.Domain.Destination;
using VisitService.Domain.Visit;

namespace VisitService.Application.Common.Interfaces;

public interface IApplicationDBContext
{
    DbSet<VisitGeneralInfo> VISIT_GENERAL_INFO { get; set; }
    DbSet<VisitType> VISIT_TYPES { get; set; }
    DbSet<VisitPurpose> VISIT_PURPOSES { get; set; }
    DbSet<Campus> CAMPUSES { get; set; }
    DbSet<Building> BUILDINGS { get; set; }
    DbSet<Floor> FLOORS { get; set; }

}
