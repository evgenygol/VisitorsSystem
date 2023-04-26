namespace VisitService.Application.Model;

public class DataResultModel<T>
{
    public bool Success { get; set; }
    public T DataResult { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}
