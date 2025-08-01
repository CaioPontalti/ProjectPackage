using System.ComponentModel;

namespace Project.Web.Enums.Account;

public enum AccountTypes
{
    [Description("Administrador")]
    SysAdmin,

    [Description("Desenvolvedor")]
    Developer,

    [Description("Lider Técnico")]
    TechLead,

    [Description("QA")]
    QA,

    [Description("Gerente de Produto")]
    ProductOwner,

    [Description("Scrum Master")]
    ScrumMaster,

    [Description("Gerente de Projeto")]
    ProjectManager,

    [Description("Arquiteto de Software")]
    SoftwareArchitect
}