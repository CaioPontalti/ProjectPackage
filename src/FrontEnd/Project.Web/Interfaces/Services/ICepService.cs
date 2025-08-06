using Project.Web.DTOs.ValueObjects.OnCepService;

namespace Project.Web.Interfaces.Services;

public interface ICepService
{
    Task<LocalAddress> SearchByPostalCode(string postalCode);
}
