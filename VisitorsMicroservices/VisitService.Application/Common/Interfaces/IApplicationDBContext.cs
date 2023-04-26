using Microsoft.EntityFrameworkCore;
using VisitService.Domain.Entity.Destination;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Application.Common.Interfaces;

public interface IApplicationDBContext
{
    DbSet<VisitGeneralInfo> VISIT_GENERAL_INFO { get; set; }
    DbSet<VisitType> VISIT_TYPES { get; set; }
    DbSet<Campus> CAMPUSES { get; set; }
    DbSet<Building> BUILDINGS { get; set; }
    DbSet<Floor> FLOORS { get; set; }
    DbSet<VisitDestinationInfo> VISIT_DESTINATION_INFO { get; set; }

}
