using System.ComponentModel;

namespace Project.Domain.Enums;

public enum Roles
{
    [Description("Usuário")]
    User,

    [Description("Administrador")]
    Admin
}