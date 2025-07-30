namespace Project.Application.UseCases.User.GetUsers.Response;

public record GetAllAccountsResponse (IEnumerable<GetAll.Response.Account> Accounts, int TotalItems);