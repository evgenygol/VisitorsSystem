namespace VisitService.Domain.Common;

public abstract class BaseNamedEntity: BaseEntity <int>
{
    public string NAME { get; set; } = string.Empty;
    public int ORDER_ID { get; set; }
}
