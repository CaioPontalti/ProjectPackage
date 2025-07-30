namespace Project.Web.DTOs.Response.Auth;

public record Login (string Token, User.GetAll.Account User);