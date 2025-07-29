namespace Project.Web.DTOs.Response.User.GetAll;

public record GetAllUser(IEnumerable<User> Users, int TotalItems);