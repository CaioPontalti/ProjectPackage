using MongoDB.Bson;

namespace Project.Domain.Entities.v1;

public class User
{
    public string Id { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; }

    public string Role { get; set; }

    public DateTime CreatedDate { get; private set; }

    public DateTime LastUpdatedDate { get; private set; }

    public bool IsActive { get; private set; }


    public User() { }

    public User(ObjectId id, string email, string name, string passwordHash, string role, DateTime createdDate, DateTime lastUpdatedDate, bool isActive)
    {
        Id = id.ToString();
        Email = email;
        Name = name;
        PasswordHash = passwordHash;
        Role = role;
        CreatedDate = createdDate;
        LastUpdatedDate = lastUpdatedDate;
        IsActive = isActive;
    }

    public static User Create(string email, string name, string password, string role)
    {
        var createdDate = DateTime.Now;
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return new User(ObjectId.GenerateNewId(), email, name, hashPassword, role, createdDate, createdDate, isActive: true);
    }

    public void Update(string name)
    {
        Name = name;
        LastUpdatedDate = DateTime.Now;
    }

    public void SetInactive()
    {
        IsActive = false;
    }
}