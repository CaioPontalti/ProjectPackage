namespace Project.Application.UseCases.User.GetUsers.Response;

public record GetAllUsersResponse (IEnumerable<DTOs.User.GetAll.UserResponse> Users);