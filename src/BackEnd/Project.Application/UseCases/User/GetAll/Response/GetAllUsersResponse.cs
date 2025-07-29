namespace Project.Application.UseCases.User.GetUsers.Response;

public record GetAllUsersResponse (IEnumerable<GetAll.Response.User> Users, int TotalItems);