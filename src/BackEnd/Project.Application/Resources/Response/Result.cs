using System.Net;
using System.Text.Json.Serialization;

namespace Project.Application.Resources.Response;

public class Result
{
    public bool IsSuccess { get; protected set; }
    public List<string> Errors { get; protected set; } = new();

    [JsonIgnore]
    public HttpStatusCode StatusCode { get; protected set; }

    protected Result() { }

    public static Result Success(HttpStatusCode statusCode)
        => new Result
        {
            IsSuccess = true,
            StatusCode = statusCode
        };

    public static Result Failure(HttpStatusCode statusCode, params string[] errors)
        => new Result
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Errors = errors.ToList()
        };
}


public class Result<T> : Result
{
    
    public T Data { get; private set; }

    private Result() { }

    public static Result<T> Success(HttpStatusCode statusCode, T data)
        => new Result<T>
        {
            IsSuccess = true,
            Data = data,
            StatusCode = statusCode
        };

    public static Result<T> Failure(HttpStatusCode statusCode, params string[] errors)
        => new Result<T>
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Errors = errors.ToList()
        };
}