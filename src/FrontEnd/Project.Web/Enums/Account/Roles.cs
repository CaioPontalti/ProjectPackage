using System.ComponentModel;

namespace Project.Web.Enums.Account;

public enum Roles
{
    [Description("Usuário")]
    User,

    [Description("Administrador")]
    Admin
}