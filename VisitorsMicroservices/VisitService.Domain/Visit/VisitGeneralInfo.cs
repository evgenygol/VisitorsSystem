using VisitService.Domain.Common;

namespace VisitService.Domain.Visit;

public class VisitGeneralInfo : BaseEntity<int>
{
    public string VISIT_NAME { get; set; } = string.Empty;
    public int VISIT_TYPE_ID { get; set; }
    public string VISIT_REMARKS { get; set; } = string.Empty;
    public int INVITER_ID { get; set; }
    public int ESCORT_ID { get; set; }
    public int HOST_ID { get; set; }
    public DateTime? VISIT_START_DATE { get; set; }
    public DateTime? VISIT_END_DATE { get; set; }
    public DateTime CREATED { get; set; }
    public DateTime LAST_CHANGED { get; set; }
    public int LAST_CHANGED_BY_EMPID { get; set; }
    public bool DELETED { get; set; }
}
