namespace Project.Application.UseCases.User.GetAll.Response;

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public string Theme { get; set; }

    public static explicit operator User(Domain.Entities.v1.User user)
    {
        return new User
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            CreatedDate = user.CreatedDate,
            LastUpdatedDate = user.LastUpdatedDate,
            IsActive = user.IsActive,
            Theme = user.Theme
        };
    } 
}