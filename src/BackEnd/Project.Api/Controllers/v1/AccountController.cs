using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Extensions;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.Active;
using Project.Application.UseCases.Account.Active.Request;
using Project.Application.UseCases.Account.Create;
using Project.Application.UseCases.Account.Create.Request;
using Project.Application.UseCases.Account.Create.Response;
using Project.Application.UseCases.Account.GetAll;
using Project.Application.UseCases.Account.GetAll.Response;
using Project.Application.UseCases.Account.Inactivate;
using Project.Application.UseCases.Account.Inactivate.Request;

namespace Project.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// Create a new account in the app
        /// </summary>
        /// <remarks>
        /// Example of successful 201 response:
        ///
        ///     {  
        ///        "isSuccess": true,
        ///        "data": {
        ///             id: "686abc937455f81ad2384c9b"
        ///        },
        ///        "errors": []
        ///      }
        ///     
        /// Example of error 400 | 409 | 500 response:
        ///
        ///     {
        ///        "isSuccess" : false,
        ///        "data": null,
        ///        "errors" : [
        ///             "O campo e-mail é inválido.",
        ///             "Já existe uma conta cadastrada com esse e-mail.",
        ///             "System.DivideByZeroException: Attempted to divide by zero."
        ///        ]
        ///     }
        ///     
        ///   accountType: Define os tipos de conta que representam os papéis de usuários dentro do sistema:
        ///   - Developer, TechLead, QA, ProductOwner, ScrumMaster, ProjectManager, SoftwareArchitect
        ///
        ///   role: Define o tipo de acesso da conta de usuário:
        ///   - User ou Admin
        ///
        /// </remarks>
        /// <param name="useCaseCreateAccount">Service that executes the use case logic.</param>
        /// <param name="request">Resquest Object</param>
        /// <returns>Return Messages</returns>
        /// <response code="201">Account created successfully</response>
        /// <response code="400">Request Invalid</response>
        /// <response code="409">Conflict in Operation (ex: Account already exists)</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Result<CreateAccountResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAccountAsync(
            [FromServices] ICreateAccountUseCase useCaseCreateAccount,
            [FromBody] CreateAccountRequest request)
        {
            var result = await useCaseCreateAccount.ExecuteAsync(request);

            return result.ToActionResult();
        }

        /// <summary>
        /// Get all accounts from the app
        /// </summary>
        /// <remarks>
        /// Example of successful 200 response:
        ///
        ///     {
        ///         "data": {
        ///             "accounts": [
        ///                 {
        ///                     "id": "688782a9ec629195423debb3",
        ///                     "email": "user@user.com",
        ///                     "role": "development",
        ///                     "accountType":"Admin"
        ///                     "createdDate": "2025-07-28T14:01:13.05Z",
        ///                     "lastUpdatedDate": "2025-07-28T14:01:13.05Z",
        ///                     "isActive": true
        ///                 }
        ///             ],
        ///             "totalItems": 1
        ///         },
        ///         "isSuccess": true,
        ///         "errors": []
        ///     }
        ///
        /// Example of error 500 response:
        ///
        ///     {
        ///         "isSuccess": false,
        ///         "data": null,
        ///         "errors": [
        ///             "System.Exception: Internal server error."
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <param name="useCaseGetAllAccounts">Service that executes the use case logic.</param>
        /// <param name="search"> Texto para pesquisa</param>
        /// <param name="page">Pagina </param>
        /// <param name="pageSize">Itens por página</param>
        /// <returns>Return list of accounts</returns>
        /// <response code="200">Accounts retrieved successfully</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("accounts")]
        [ProducesResponseType(typeof(Result<GetAllAccountsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAccountsAsync(
            [FromServices] IGetAllAccountsUseCase useCaseGetAllAccounts,
            [FromQuery] int page, int pageSize, string search)
        {
            var result = await useCaseGetAllAccounts.ExecuteAsync(page, pageSize, search);

            return result.ToActionResult();
        }

        /// <summary>
        /// Update account status to inactive in the app
        /// </summary>
        /// <remarks>
        /// Example of successful 200 response:
        ///
        ///     {
        ///        "isSuccess" : true,
        ///        "data": null,
        ///        "errors" : []
        ///     }
        ///     
        /// Example of error 400 | 404 | 409 | 500 response:
        ///
        ///     {
        ///        "isSuccess" : false,
        ///        "data": null,
        ///        "errors" : [
        ///             "O campo id é obrigatório.",
        ///             "Conta não encontrada.",
        ///             "A conta já está aiva.",
        ///             "System.DivideByZeroException: Attempted to divide by zero."
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <param name="useCaseInactiveUser">Service that executes the use case logic.</param>
        /// <param name="request">Resquest Object</param>
        /// <returns>Return Messages</returns>
        /// <response code="200">Status account updated successfully</response>
        /// <response code="400">Request Invalid</response>
        /// <response code="404">Account not found</response>
        /// <response code="409">Account is already inactive</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPatch("inactive")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        public async Task<IActionResult> InactivateAccountAsync(
            [FromServices] IInactivateAccountUseCase useCaseInactiveUser,
            [FromBody] InactiveAccountRequest request)
        {
            var result = await useCaseInactiveUser.ExecuteAsync(request);

            return result.ToActionResult();
        }

        /// <summary>
        /// Update account status to active in the app
        /// </summary>
        /// <remarks>
        /// Example of successful 200 response:
        ///
        ///     {
        ///        "isSuccess" : true,
        ///        "data": null,
        ///        "errors" : []
        ///     }
        ///     
        /// Example of error 400 | 404 | 409 | 500 response:
        ///
        ///     {
        ///        "isSuccess" : false,
        ///        "data": null,
        ///        "errors" : [
        ///             "O campo id é obrigatório.",
        ///             "Conta não encontrada.",
        ///             "A conta já está ativo.",
        ///             "System.DivideByZeroException: Attempted to divide by zero."
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <param name="useCaseActiveAccount">Service that executes the use case logic.</param>
        /// <param name="request">Resquest Object</param>
        /// <returns>Return Messages</returns>
        /// <response code="200">Status account updated successfully</response>
        /// <response code="400">Request Invalid</response>
        /// <response code="404">Account not found</response>
        /// <response code="409">Account is already inactive</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPatch("active")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        public async Task<IActionResult> IActiveAccountAsync(
            [FromServices] IActiveAccountUseCase useCaseActiveAccount,
            [FromBody] ActiveAccountRequest request)
        {
            var result = await useCaseActiveAccount.ExecuteAsync(request);

            return result.ToActionResult();
        }
    }
}