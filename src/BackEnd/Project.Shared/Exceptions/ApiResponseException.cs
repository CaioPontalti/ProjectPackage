namespace Project.Shared.Exceptions;

public class ApiResponseException : Exception
{
    public ApiResponseException(string message) : base(message) { }
}