using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Extensions;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.GetAll.Response;
using Project.Application.UseCases.Profile.GetById;
using Project.Application.UseCases.Profile.GetById.Response;

namespace Project.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// Retrieve profile data based on the provided account ID.
        /// </summary>
        /// <remarks>
        /// Example of successful 200 response:
        /// 
        ///     {
        ///         "isSuccess": true,
        ///         "data": {
        ///             "profile": {
        ///                 "id": "64f2c248f1ce1e00135d2c31",
        ///                 "accountId": "bdc019aa32904f72b7b70a8bdf1e0d97",
        ///                 "name": "Usuário Santana",
        ///                 "birthDate": "1993-08-04T00:00:00",
        ///                 "cellPhone": "(11) 91234-5678",
        ///                 "address": {
        ///                     "postalCode": null,
        ///                     "addressDescription": null,
        ///                     "number": null,
        ///                     "state": null,
        ///                     "city": null,
        ///                     "neighborhood": null,
        ///                     "complement": null
        ///                 },
        ///                 "cellPhone": null
        ///             }
        ///         },
        ///         "errors": []
        ///     }
        /// 
        /// Example of error 400 | 404 | 500 response:
        /// 
        ///     {
        ///         "isSuccess": false,
        ///         "data": null,
        ///         "errors": [
        ///             "AccountId é inválido.",
        ///             "Perfil não encontrado.",
        ///             "System.NullReferenceException: Object reference not set to an instance of an object."
        ///         ]
        ///     }
        /// </remarks>
        /// <param name="useCaseGetByAccountId">Service that executes the use case logic.</param>
        /// <param name="accountId">Unique identifier of the account.</param>
        /// <returns>Standard result wrapper containing profile data or validation errors.</returns>
        /// <response code="200">Profile retrieved successfully.</response>
        /// <response code="400">Invalid request parameters.</response>
        /// <response code="404">Profile not found.</response>
        /// <response code="500">Unexpected internal server error.</response>

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(Result<GetByAccountIdResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByAccountIdAsync(
            [FromServices] IGetByAccountIdUseCase useCaseGetByAccountId,
            [FromQuery] string accountId)
        {
            var result = await useCaseGetByAccountId.ExecuteAsync(accountId);

            return result.ToActionResult();
        }
    }
}