using Microsoft.AspNetCore.Mvc;
using Project.Api.Extensions;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Auth.Login;
using Project.Application.UseCases.Auth.Login.Request;
using Project.Application.UseCases.Auth.Login.Response;

namespace Project.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Login user in the app
        /// </summary>
        /// <remarks>
        /// Example of successful 200 response:
        ///
        ///     {  
        ///        "isSuccess": true,
        ///        "data": {
        ///             "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5",
        ///             "refreshToke": "0de41f83-83ec-42e8-a40d-146ba1ae2d6c"
        ///        },
        ///        "errors": []
        ///      }
        ///     
        /// Example of error 400 | 500 response:
        ///
        ///     {
        ///        "isSuccess" : false,
        ///        "data": null,
        ///        "errors" : [
        ///             "O campo e-mail é inválido.",
        ///             "Usuário e/ou senha inválidos",
        ///             "System.DivideByZeroException: Attempted to divide by zero."
        ///        ]
        ///     }
        ///
        /// </remarks>
        /// <param name="useCaseLogin">Service that executes the use case logic.</param>
        /// <param name="request">Resquest Object</param>
        /// <returns>Return Messages</returns>
        /// <response code="200">Login successful</response>
        /// <response code="400">Request Invalid</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("login")]
        [ProducesResponseType(typeof(Result<LoginResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(
            [FromServices] ILoginUseCase useCaseLogin,
            [FromBody] LoginRequest request)
        {
            var result = await useCaseLogin.ExecuteAsync(request);

            return result.ToActionResult();
        }
    }
}