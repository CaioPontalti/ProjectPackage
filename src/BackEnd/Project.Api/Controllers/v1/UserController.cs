using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Extensions;
using Project.Application.Resources.Response;
using Project.Application.UseCases.User.Create;
using Project.Application.UseCases.User.Create.Request;
using Project.Application.UseCases.User.Create.Response;
using Project.Application.UseCases.User.GetAll;
using Project.Application.UseCases.User.GetById;
using Project.Application.UseCases.User.GetUsers.Response;
using Project.Application.UseCases.User.Inactivate;
using Project.Application.UseCases.User.Update;
using Project.Application.UseCases.User.Update.Request;

namespace Project.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Create a new user in the app
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
        ///             "Já existe um usuário cadastrado com esse e-mail.",
        ///             "System.DivideByZeroException: Attempted to divide by zero."
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <param name="useCaseCreateUser"></param>
        /// <param name="request">Resquest Object</param>
        /// <returns>Return Messages</returns>
        /// <response code="201">User created successfully</response>
        /// <response code="400">Request Invalid</response>
        /// <response code="409">Conflict in Operation (ex: User already exists)</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [ProducesResponseType(typeof(Result<CreateUserResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUserAsync(
            [FromServices] ICreateUserUseCase useCaseCreateUser,
            [FromBody] CreateUserRequest request)
        {
            var result = await useCaseCreateUser.ExecuteAsync(request);

            return result.ToActionResult();
        }

        /// <summary>
        /// Update a user in the app
        /// </summary>
        /// <remarks>
        /// Example of successful 204 response:
        ///
        ///     No Content
        ///     
        /// Example of error 400 | 404 | 500 response:
        ///
        ///     {
        ///        "isSuccess" : false,
        ///        "data": null,
        ///        "errors" : [
        ///             "O campo name é obrigatório.",
        ///             "Usuário não encontrado.",
        ///             "System.DivideByZeroException: Attempted to divide by zero."
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <param name="useCaseUpdateUser"></param>
        /// <param name="request">Resquest Object</param>
        /// <param name="id">Entity Id</param>
        /// <returns>Return Messages</returns>
        /// <response code="204">User updated successfully</response>
        /// <response code="400">Request Invalid</response>
        /// <response code="404">User not found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUserAsync(
            [FromServices] IUpdateUserUseCase useCaseUpdateUser,
            [FromBody] UpdateUserRequest request,
            string id)
        {
            var result = await useCaseUpdateUser.ExecuteAsync(id, request);

            return result.ToActionResult();
        }

        /// <summary>
        /// Get all users from the app
        /// </summary>
        /// <remarks>
        /// Example of successful 200 response:
        ///
        ///     {
        ///         "data": {
        ///             "users": [
        ///                 {
        ///                     "id": "68712260b37de642117fb3a7",
        ///                     "name": "Name",
        ///                     "email": "Mail",
        ///                     "role": "User",
        ///                     "createdDate": "2025-07-11T14:40:31.993Z",
        ///                     "lastUpdatedDate": "2025-07-11T14:40:31.993Z",
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
        /// <param name="useCaseGetAllUsers"></param>
        /// <param name="search"> Texto para pesquisa</param>
        /// <param name="page">Pagina </param>
        /// <param name="pageSize">Itens por página</param>
        /// <returns>Return list of users</returns>
        /// <response code="200">Users retrieved successfully</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("users")]
        [ProducesResponseType(typeof(Result<GetAllAccountsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsersAsync(
            [FromServices] IGetAllUsersUseCase useCaseGetAllUsers,
            [FromQuery] int page, int pageSize, string search)
        {
            var result = await useCaseGetAllUsers.ExecuteAsync(page, pageSize, search);

            return result.ToActionResult();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetByIdUserAsync(
            [FromServices] IGetByIdUserUseCase useCaseGetByIdUser,
            [FromQuery] string id)
        {
            var result = await useCaseGetByIdUser.ExecuteAsync(id);

            return result.ToActionResult();
        }

        /// <summary>
        /// Update user status to inactive in the app
        /// </summary>
        /// <remarks>
        /// Example of successful 204 response:
        ///
        ///     No Content
        ///     
        /// Example of error 400 | 404 | 409 | 500 response:
        ///
        ///     {
        ///        "isSuccess" : false,
        ///        "data": null,
        ///        "errors" : [
        ///             "O campo id é obrigatório.",
        ///             "Usuário não encontrado.",
        ///             "O usuário já está inativo.",
        ///             "System.DivideByZeroException: Attempted to divide by zero."
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <param name="useCaseInactiveUser"></param>
        /// <param name="id">Entity Id</param>
        /// <returns>Return Messages</returns>
        /// <response code="204">Status user updated successfully</response>
        /// <response code="400">Request Invalid</response>
        /// <response code="404">User not found</response>
        /// <response code="409">User is already inactive</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> InactivateUserAsync(
            [FromServices] IInactivateUserUseCase useCaseInactiveUser,
            string id)
        {
            var result = await useCaseInactiveUser.ExecuteAsync(id);

            return result.ToActionResult();
        }
    }
}