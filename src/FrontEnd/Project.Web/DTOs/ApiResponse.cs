namespace Project.Web.DTOs;

public class ApiResponse<T>
{
    public T? Data { get; set; } = default!;
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; } = new();
}