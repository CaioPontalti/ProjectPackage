namespace Project.Web.DTOs.Response.User.GetAll;

public record GetAllUser(IEnumerable<Account> Accounts, int TotalItems);