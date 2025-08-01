using Project.Domain.Entities.v1;
using Project.Domain.ValueObjects.Auth;

namespace Project.Domain.Interfaces.Services;

public interface IAuthService
{
    Token GenerateToken(Account user);
}