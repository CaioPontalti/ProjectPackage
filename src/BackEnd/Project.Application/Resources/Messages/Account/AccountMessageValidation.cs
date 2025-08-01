namespace Project.Application.Resources.Messages.Account;

public static class AccountMessageValidation
{
    public const string AccountExists = "Já existe uma conta cadastrada com esse e-mail.";
    public const string IdRequerid = "O campo id é obrigatório.";
    public const string AccountEmailRequerid = "O campo e-mail é obrigatório.";
    public const string AccountEmailInvalid = "O campo e-mail é inválido.";
    public const string AccountPasswordRequired = "O campo senha é obrigatório.";
    public const string AccountRoleIsInvalid = "O campo role é inválido. Os valores possíveis são: Usuário ou Administrador";
    public const string AccountTypeIsInvalid = "O campo tipo da conta é inválido. Os valores possíveis são: Desenvolvedor, Lider Técnico, QA, " +
        "Gerente de Produto, Administrador, Scrum Master, Gerente de Projeto, Arquiteto de Software.";
    public const string AccountNotFound = "Conta não encontrada.";
    public const string AccountAlreadyInactive = "A conta já está inativa.";
}