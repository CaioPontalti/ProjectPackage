using Project.Web.DTOs.ValueObjects.Profile;
using System.ComponentModel.DataAnnotations;

namespace Project.Web.DTOs.Response.Profile.GetByAccountId;

public class Profile
{
    public string Id { get; set; }
    public string AccountId { get; set; }
    [Required(ErrorMessage = "O campo 'Nome' é obrigatório!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O campo 'Dt. Nascimento' é obrigatório!")]
    public DateTime? BirthDate { get; set; }
    public Address Address { get; set; }
    [Required(ErrorMessage = "O campo 'Telefone' é obrigatório!")]
    public string CellPhone { get; set; }
}