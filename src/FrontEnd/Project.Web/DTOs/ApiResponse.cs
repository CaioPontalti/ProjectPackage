namespace Project.Web.DTOs;

public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; } = new();
}

public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; } = default!;
}