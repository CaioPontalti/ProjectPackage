namespace Project.Web.DTOs.Response.User.GetAll;

public record GetAllAccount(IEnumerable<Account> Accounts, int TotalItems);