using VisitService.Domain.Visit;

namespace VisitService.Application.Model;

public class VisitResultModel
{
    public bool Success { get; set; }
    public VisitGeneralInfo Visit { get; set; } = new();
    public string ErrorMessage { get; set; } = string.Empty;
}
