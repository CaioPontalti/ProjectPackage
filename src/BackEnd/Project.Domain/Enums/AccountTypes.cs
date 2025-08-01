using System.ComponentModel;

namespace Project.Domain.Enums;

public enum AccountTypes
{
    [Description("Desenvolvedor")]
    Developer = 1,

    [Description("Lider Técnico")]
    TechLead = 2,

    [Description("QA")]
    QA = 3,

    [Description("Gerente de Produto")]
    ProductOwner = 4,

    [Description("Administrador")]
    SysAdmin = 5,

    [Description("Scrum Master")]
    ScrumMaster = 6,

    [Description("Gerente de Projeto")]
    ProjectManager = 7,

    [Description("Arquiteto de Software")]
    SoftwareArchitect = 8
}