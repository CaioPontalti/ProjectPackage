namespace Project.Application.UseCases.User.GetUsers.Response;

public record GetAllUsersResponse (IEnumerable<DTOs.v1.User.User> Users, int TotalItems);