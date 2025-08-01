using System.ComponentModel.DataAnnotations;

namespace Project.Web.DTOs.Response.User.GetById;

public record Account
{
    public string Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    public DateTime? CreatedDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public bool IsActive { get; set; }
}