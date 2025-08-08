using MongoDB.Bson;

namespace Project.Domain.Entities.v1;

public class Account
{
    public string Id { get; private set; }

    public string Email { get; private set; }

    public string PasswordHash { get; private set; }

    public string AccountType { get; set; }

    public string Role { get; set; }

    public DateTime CreatedDate { get; private set; }

    public DateTime LastUpdatedDate { get; private set; }

    public bool IsActive { get; private set; }


    public Account() { }

    public Account(ObjectId id, string email, string passwordHash, string role, string accountType, DateTime createdDate, DateTime lastUpdatedDate, bool isActive)
    {
        Id = id.ToString();
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        AccountType = accountType;
        CreatedDate = createdDate;
        LastUpdatedDate = lastUpdatedDate;
        IsActive = isActive;
    }

    public static Account Create(string email, string password, string role, string accountType)
    {
        var createdDate = DateTime.Now;
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return new Account(ObjectId.GenerateNewId(), email, hashPassword, role, accountType, createdDate, createdDate, isActive: true);
    }

    public void SetInactive()
    {
        IsActive = false;
    }

    public void SetActive()
    {
        IsActive = true;
    }
}