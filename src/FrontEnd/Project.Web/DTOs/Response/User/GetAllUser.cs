namespace Project.Web.DTOs.Response.User;

public record GetAllUser(IEnumerable<User> Users, int TotalItems);