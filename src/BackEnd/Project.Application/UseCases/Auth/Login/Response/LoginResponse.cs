namespace Project.Application.UseCases.Auth.Login.Response;

public record LoginResponse(string Token, Account.GetAll.Response.Account User);