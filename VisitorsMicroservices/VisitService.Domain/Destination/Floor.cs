using VisitService.Domain.Common;

namespace VisitService.Domain.Destination;

public class Floor : BaseNamedEntity
{
    public int CAMPUS_ID { get; set; }
    public int BUILDING_ID { get; set; }
}
