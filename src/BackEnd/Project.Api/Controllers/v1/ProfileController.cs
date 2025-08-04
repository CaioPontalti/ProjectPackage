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