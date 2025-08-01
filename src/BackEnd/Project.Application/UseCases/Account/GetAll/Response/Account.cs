namespace Project.Application.UseCases.Account.GetAll.Response;

public class Account
{
    public string Id { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }

    public string AccountType { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public bool IsActive { get; set; }

    public static explicit operator Account(Domain.Entities.v1.Account account)
    {
        return new Account
        {
            Id = account.Id,
            Email = account.Email,
            Role = account.Role,
            AccountType = account.AccountType,
            CreatedDate = account.CreatedDate,
            LastUpdatedDate = account.LastUpdatedDate,
            IsActive = account.IsActive
        };
    } 
}