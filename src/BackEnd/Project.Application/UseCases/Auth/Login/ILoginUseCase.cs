using Project.Application.Resources.Response;
using Project.Application.UseCases.Auth.Login.Request;
using Project.Application.UseCases.Auth.Login.Response;

namespace Project.Application.UseCases.Auth.Login;

public interface ILoginUseCase
{
    Task<Result<LoginResponse>> ExecuteAsync(LoginRequest request);
}