using VisitService.Domain.Common;

namespace VisitService.Domain.Entity.Destination;

public class Floor : BaseNamedEntity
{
    public int CAMPUS_ID { get; set; }
    public int BUILDING_ID { get; set; }
}
