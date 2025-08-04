namespace Project.Web.DTOs.Response.Account.GetAll;

public record GetAllAccount(IEnumerable<Account> Accounts, int TotalItems);