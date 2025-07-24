using Project.Application.Resources.Messages.Auth;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Auth.Login.Request;
using Project.Application.UseCases.Auth.Login.Response;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;
using System.Net;

namespace Project.Application.UseCases.Auth.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginUseCase(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<Result<LoginResponse>> ExecuteAsync(LoginRequest request)
    {
        request.Validate();

        if (request.HasNotification())
            return Result<LoginResponse>.Failure(HttpStatusCode.BadRequest, request.Notifications.ToArray());

        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user is null)
            return Result<LoginResponse>.Failure(HttpStatusCode.BadRequest, AuthMessageValidation.UserOrPasswordInvalid);

        var verifyPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!verifyPassword)
            return Result<LoginResponse>.Failure(HttpStatusCode.BadRequest, AuthMessageValidation.UserOrPasswordInvalid);

        var token = _authService.GenerateToken(user);

        return Result<LoginResponse>
            .Success(HttpStatusCode.OK, new LoginResponse(token.AcccessToken));
    }
}