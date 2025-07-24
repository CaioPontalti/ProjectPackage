namespace Project.Application.Resources.Messages.Auth;

public static class AuthMessageValidation
{
    public const string AuthEmailRequerid = "O campo e-mail é obrigatório.";
    public const string AuthEmailInvalid = "O campo e-mail é inválido.";
    public const string PasswordRequerid = "O campo senha é obrigatório.";
    public const string UserOrPasswordInvalid = "Usuário e/ou senha inválidos";
    public const string RefreshTokenCookieNotFound = "O envio do Token é obrigatório";
}