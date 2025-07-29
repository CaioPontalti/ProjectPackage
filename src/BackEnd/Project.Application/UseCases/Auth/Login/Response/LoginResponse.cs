namespace Project.Application.UseCases.Auth.Login.Response;

public record LoginResponse(string Token, User.GetAll.Response.User User);