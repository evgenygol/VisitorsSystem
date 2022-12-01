using VisitService.Domain.Visit;

namespace VisitService.Application.Model;

public class DataListResultModel<T>
{
    public bool Success { get; set; }
    public List<T> DataResults { get; set; } = new();
    public string ErrorMessage { get; set; } = string.Empty;
}
