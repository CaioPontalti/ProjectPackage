namespace Project.Application.UseCases.User.GetUsers.Response;

public record GetAllUsersResponse (IEnumerable<GetAll.Response.Account> Accounts, int TotalItems);