using Project.Application.DTOs.v1.User;

namespace Project.Application.UseCases.Auth.Login.Response;

public record LoginResponse(string Token, DTOs.v1.User.User User);