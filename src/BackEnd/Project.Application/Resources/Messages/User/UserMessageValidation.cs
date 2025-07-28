namespace Project.Application.Resources.Messages.User;

public static class UserMessageValidation
{
    public const string UserExists = "Já existe um usuário cadastrado com esse e-mail.";
    public const string UserNameRequerid = "O campo nome é obrigatório.";
    public const string IdRequerid = "O campo id é obrigatório.";
    public const string UserEmailRequerid = "O campo e-mail é obrigatório.";
    public const string UserEmailInvalid = "O campo e-mail é inválido.";
    public const string UserPasswordRequired = "O campo senha é obrigatório.";
    public const string UserRoleRequired = "O campo role é obrigatório.";
    public const string UserNotFound = "Usuário não encontrado.";
    public const string UserAlreadyInactive = "O usuário já está inativo.";
}