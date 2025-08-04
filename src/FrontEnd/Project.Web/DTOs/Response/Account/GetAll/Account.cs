namespace Project.Web.DTOs.Response.Account.GetAll;

public record Account(string Id, string Email, string Role, string AccountType, DateTime CreatedDate, DateTime LastUpdatedDate, bool IsActive);