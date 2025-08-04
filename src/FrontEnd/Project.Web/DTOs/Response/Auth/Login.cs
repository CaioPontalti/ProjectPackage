namespace Project.Web.DTOs.Response.Auth;

public record Login (string Token, Account.GetAll.Account Account);