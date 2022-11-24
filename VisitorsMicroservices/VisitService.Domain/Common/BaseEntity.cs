namespace VisitService.Domain.Common;

public abstract class BaseEntity<T>
{
    public virtual T ID { get; set; }
}
