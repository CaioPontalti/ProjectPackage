namespace Project.Application.UseCases.Account.GetAll.Response;

public record GetAllAccountsResponse (IEnumerable<Account> Accounts, int TotalItems);