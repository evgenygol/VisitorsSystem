using System.ComponentModel.DataAnnotations.Schema;
using VisitService.Domain.Common;
using VisitService.Domain.Entity.Visit;

namespace VisitService.Domain.Entity.Destination;

public class VisitDestinationInfo : BaseEntity<int>
{
    public int VISIT_ID { get; set; }
    public int CAMPUS_ID { get; set; }
    public int BUILDING_ID { get; set; }
    public int FLOOR_ID { get; set; }
}

