using VisitService.Domain.Visit;

namespace VisitService.Application.Model;

public class VisitsResultModel
{
    public bool Success { get; set; }
    public List<VisitGeneralInfo> Visits { get; set; } = new();
    public string ErrorMessage { get; set; } = string.Empty;
}
